import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CartItem } from '../models/cartItem.model';
import { Product } from '../models/product.model';
import { User } from '../models/user.model';
import { AccountService } from '../services/account.service';
import { CartItemsService } from '../services/cart-items.service';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrl: './product-category.component.css',
  animations: [
    trigger('filterPanelAnimation', [
      state(
        'collapsed',
        style({
          height: '0',
          overflow: 'hidden',
          opacity: 0,
        })
      ),
      state(
        'expanded',
        style({
          height: '*',
          opacity: 1,
        })
      ),
      transition('collapsed <=> expanded', [animate('300ms ease-in-out')]),
    ]),
  ],
})
export class ProductCategoryComponent implements OnInit {
  public title: string = '';
  public currentUser: User | undefined;
  public products: Product[] = [];
  public filteredProducts: Product[] = [];
  public suppliers: string[] = [];
  public deliveryMethods: string[] = [];
  public filters = {
    minPrice: null,
    maxPrice: null,
    inStock: false,
    supplier: '',
    deliveryMethod: '',
  };

  public filterPanelOpen = false;

  private readonly categoryMap: { [key: string]: { id: number; title: string } } = {
    motherboards: { id: 1, title: 'Motherboards' },
    cpus: { id: 2, title: 'CPUs' },
    gpus: { id: 3, title: 'GPUs' },
    ram: { id: 4, title: 'RAM' },
    storages: { id: 5, title: 'Storages' },
    'power-supplies': { id: 6, title: 'Power Supplies' },
    'pc-cases': { id: 7, title: 'PC Cases' },
    coolers: { id: 8, title: 'Coolers' },
    fans: { id: 9, title: 'Fans' },
    monitors: { id: 10, title: 'Monitors' },
    keyboards: { id: 11, title: 'Keyboards' },
    mice: { id: 12, title: 'Mice' },
    'mouse-pads': { id: 13, title: 'Mouse Pads' },
    headsets: { id: 14, title: 'Headsets' },
  };

  constructor(
    private readonly productsService: ProductsService,
    private readonly cartItemsService: CartItemsService,
    private readonly accountService: AccountService,
    private readonly snackBar: MatSnackBar,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const categoryName = params.get('categoryName');

      if (categoryName && this.categoryMap[categoryName]) {
        const category = this.categoryMap[categoryName];
        this.title = category.title;
        this.resetFilters();
        this.getProductsByCategory(category.id);
      } else {
        this.title = 'Category Not Found';
        this.products = [];
        this.filteredProducts = [];
      }
    });
  }

  getProductsByCategory(categoryId: number): void {
    if (categoryId === 0) {
      console.error(
        'Category ID is 0. Please update the categoryMap in product-category.component.ts'
      );
      this.title = 'Configuration Error';
      this.products = [];
      this.filteredProducts = [];
      return;
    }

    this.productsService.getProductsByCategory(categoryId).subscribe({
      next: (result: Product[]) => {
        this.products = result;
        this.filteredProducts = [...this.products];
        this.extractFilters();
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  extractFilters(): void {
    const uniqueSuppliers = new Set(
      this.products.map((product) => product.supplier)
    );
    this.suppliers = Array.from(uniqueSuppliers);

    const uniqueDeliveryMethods = new Set(
      this.products.map((product) => product.deliveryMethod)
    );
    this.deliveryMethods = Array.from(uniqueDeliveryMethods);
  }

  toggleFilterPanel(): void {
    this.filterPanelOpen = !this.filterPanelOpen;
  }

  applyFilters(): void {
    this.filteredProducts = this.products.filter((product) => {
      const matchesPrice =
        (!this.filters.minPrice || product.price >= this.filters.minPrice) &&
        (!this.filters.maxPrice || product.price <= this.filters.maxPrice);
      const matchesStock = !this.filters.inStock || product.stock > 0;
      const matchesSupplier =
        !this.filters.supplier || product.supplier === this.filters.supplier;
      const matchesDelivery =
        !this.filters.deliveryMethod ||
        product.deliveryMethod === this.filters.deliveryMethod;

      return matchesPrice && matchesStock && matchesSupplier && matchesDelivery;
    });

    this.toggleFilterPanel();
  }

  resetFilters(): void {
    this.filters = {
      minPrice: null,
      maxPrice: null,
      inStock: false,
      supplier: '',
      deliveryMethod: '',
    };
    if (this.products) {
      this.filteredProducts = [...this.products];
    }
  }

  isMinPriceGreaterThanMaxPrice(): boolean {
    if (this.filters.minPrice !== null && this.filters.maxPrice !== null) {
      if (this.filters.minPrice > this.filters.maxPrice) {
        return true;
      }
    }
    return false;
  }

  isFormValid(): boolean {
    if (this.isMinPriceGreaterThanMaxPrice()) {
      return false;
    }
    if (
      this.filters.minPrice !== null &&
      (this.filters.minPrice < 0 || this.filters.minPrice > 1000000)
    ) {
      return false;
    }
    if (
      this.filters.maxPrice !== null &&
      (this.filters.maxPrice < 0 || this.filters.maxPrice > 1000000)
    ) {
      return false;
    }
    return true;
  }

  addToCart(product: Product): void {
    this.accountService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.currentUser = user;
        if (this.currentUser?.id) {
          this.cartItemsService
            .getCartItemsByUserId(this.currentUser.id)
            .subscribe({
              next: (cartItems: CartItem[]) => {
                this.cartItemsService
                  .createCartItem({
                    id: undefined,
                    productId: product.id,
                    product: undefined,
                    userId: this.currentUser!.id,
                    quantity: 1
                  })
                  .subscribe({
                    next: () => {
                      this.snackBar.open('Product added to cart', 'Close', {
                        duration: 3000,
                      });
                    },
                    error: (err) => {
                      console.error(err);
                    },
                  });
              },
              error: (err) => {
                console.error(err);
              },
            });
        } else {
          this.snackBar.open(
            'You must be logged in to add products to your cart',
            'Close',
            {
              duration: 3000,
            }
          );
        }
      },
    });
  }
}
