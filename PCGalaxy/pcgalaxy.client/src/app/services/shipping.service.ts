import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface ShippingCalculationResult {
  totalShippingFee: number;
}

@Injectable({
  providedIn: 'root'
})
export class ShippingService {
  private readonly apiUrl: string = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }

  calculateShipping(): Observable<ShippingCalculationResult> {
    return this.http.get<ShippingCalculationResult>(`${this.apiUrl}/Shipping/calculate`, { withCredentials: true });
  }
}
