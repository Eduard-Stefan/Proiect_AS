import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AdminGuard } from './guards/admin.guard';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { ViewProductComponent } from './view-product/view-product.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ProductCategoryComponent } from './product-category/product-category.component';
import { OrdersHistoryComponent } from './orders-history/orders-history.component';
import { ViewOrderComponent } from './view-order/view-order.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'admin/products', component: ProductsComponent, canActivate: [AdminGuard] },
  { path: 'product/:id', component: ViewProductComponent },

  { path: 'category/:categoryName', component: ProductCategoryComponent },

  { path: 'motherboards', redirectTo: '/category/motherboards', pathMatch: 'full' },
  { path: 'cpus', redirectTo: '/category/cpus', pathMatch: 'full' },
  { path: 'gpus', redirectTo: '/category/gpus', pathMatch: 'full' },
  { path: 'ram', redirectTo: '/category/ram', pathMatch: 'full' },
  { path: 'storages', redirectTo: '/category/storages', pathMatch: 'full' },
  { path: 'power-supplies', redirectTo: '/category/power-supplies', pathMatch: 'full' },
  { path: 'pc-cases', redirectTo: '/category/pc-cases', pathMatch: 'full' },
  { path: 'coolers', redirectTo: '/category/coolers', pathMatch: 'full' },
  { path: 'fans', redirectTo: '/category/fans', pathMatch: 'full' },
  { path: 'monitors', redirectTo: '/category/monitors', pathMatch: 'full' },
  { path: 'keyboards', redirectTo: '/category/keyboards', pathMatch: 'full' },
  { path: 'mice', redirectTo: '/category/mice', pathMatch: 'full' },
  { path: 'mouse-pads', redirectTo: '/category/mouse-pads', pathMatch: 'full' },
  { path: 'headsets', redirectTo: '/category/headsets', pathMatch: 'full' },

  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'not-authorized', component: NotAuthorizedComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },

  { path: 'orders-history', component: OrdersHistoryComponent },
  { path: 'order/:id', component: ViewOrderComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
