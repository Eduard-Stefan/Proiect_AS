import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { ActivatedRoute } from '@angular/router';
import { Order } from '../models/order.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrl: './view-order.component.css',
})
export class ViewOrderComponent implements OnInit {
  order: Order | null = null;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly orderService: OrderService,
    private readonly location: Location
  ) {}

  ngOnInit(): void {
    const orderId = String(this.route.snapshot.paramMap.get('id'));
    this.orderService.getOrderById(orderId).subscribe({
      next: (result: Order) => {
        this.order = result;
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  goBack(): void {
    this.location.back();
  }
}
