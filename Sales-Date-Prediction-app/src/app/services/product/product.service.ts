import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BACKEND_URL } from '../../injection-tokens';
import { Product } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  private urlService = 'Product/';

  constructor(
    protected http: HttpClient,
    @Inject(BACKEND_URL) private urlBack: string
  ) { }

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.urlBack}${this.urlService}`,
      {
        headers: new HttpHeaders()
      });
  }
}