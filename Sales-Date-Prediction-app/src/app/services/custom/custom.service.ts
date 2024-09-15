import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BACKEND_URL } from '../../injection-tokens';
import { CreateOrder, CustomerOrderPrediction, Order } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class CustomService {

  private urlService = 'Custom/';

  constructor(
    protected http: HttpClient,
    @Inject(BACKEND_URL) private urlBack: string
  ) { }

  public getCustomerOrderPredictio(customerName: string): Observable<CustomerOrderPrediction[]> {
    let params = new HttpParams();
    if (customerName) {
      params = params.append('customerName', customerName);
    }
    return this.http.get<CustomerOrderPrediction[]>(`${this.urlBack}${this.urlService}GetSalesDatePrediction`,
      {
        headers: new HttpHeaders(),
        params
      });
  }

  public getOrdersByCustomerId(customerId: number): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.urlBack}${this.urlService}GetOrdersByCustomerId/${customerId}`,
      {
        headers: new HttpHeaders()
      });
  }

  public createOrder(request: CreateOrder) {
    return this.http.post(`${this.urlBack}${this.urlService}CreateOrder`, request,
      {
        headers: new HttpHeaders()
      });
  }

}
