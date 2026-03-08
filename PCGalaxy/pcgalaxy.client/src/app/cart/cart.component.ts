import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CartItem } from '../models/cartItem.model';
import { Product } from '../models/product.model';
import { User } from '../models/user.model';
import { AccountService } from '../services/account.service';
import { CartItemsService } from '../services/cart-items.service';
import { ShippingService } from '../services/shipping.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {
  cartId: string = '';
  cartItems: CartItem[] = [];
  currentUser: User | undefined;
  product: Product | undefined;
  deliveryFee: number = 0;
  total: number = 0;

  constructor(
    private cartItemsService: CartItemsService,
    private accountService: AccountService,
    private shippingService: ShippingService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.accountService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.currentUser = user;
        if (this.currentUser?.id) {
          this.getCartItemsByUserId(this.currentUser.id);
        }
      },
    });
  }

  getCartItemsByUserId(userId: string): void {
    this.cartItemsService.getCartItemsByUserId(userId).subscribe({
      next: (result: CartItem[]) => {
        this.cartItems = result;
        this.total = this.cartItems.reduce((acc, item) => acc + (item.product!.price * item.quantity), 0);

        this.shippingService.calculateShipping().subscribe({
          next: (res) => {
            this.deliveryFee = res.totalShippingFee;
            this.total += this.deliveryFee;
          },
          error: (err) => {
            console.error('Error fetching shipping fee', err);
          }
        });
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  deleteCartItem(id: string): void {
    this.cartItemsService.deleteCartItem(id).subscribe({
      next: () => {
        this.getCartItemsByUserId(this.currentUser!.id);
        this.snackBar.open('Item removed from cart', 'Close', {
          duration: 3000,
        });
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  increaseQuantity(item: CartItem): void {
    if (item.product && item.quantity < item.product.stock) {
      item.quantity++;
      this.updateItemInBackend(item);
    } else {
      this.snackBar.open('Quantity cannot exceed stock', 'Close', { duration: 3000 });
    }
  }

  decreaseQuantity(item: CartItem): void {
    if (item.quantity > 1) {
      item.quantity--;
      this.updateItemInBackend(item);
    }
  }

  private updateItemInBackend(item: CartItem): void {
    this.cartItemsService.updateCartItem(item).subscribe({
      next: () => {
        this.total = this.cartItems.reduce((acc, curr) => acc + (curr.product!.price * curr.quantity), 0);

        this.shippingService.calculateShipping().subscribe({
          next: (res) => {
            this.deliveryFee = res.totalShippingFee;
            this.total += this.deliveryFee;
          }
        });
      },
      error: (err) => {
        this.snackBar.open('Error updating quantity', 'Close', { duration: 3000 });
      }
    });
  }

  onQuantityChange(item: CartItem): void {
    if (!item.quantity || item.quantity < 1) {
      item.quantity = 1;
    } 
    else if (item.product && item.quantity > item.product.stock) {
      item.quantity = item.product.stock;
      this.snackBar.open('Quantity cannot exceed stock', 'Close', { duration: 3000 });
    }
    
    this.updateItemInBackend(item);
  }

  preventInvalidCharacters(event: KeyboardEvent): void {
    if (!/^[0-9]$/.test(event.key)) {
      event.preventDefault();
    }
  }
}
