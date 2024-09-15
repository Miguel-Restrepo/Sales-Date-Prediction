import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BACKEND_URL } from '../../injection-tokens';
import { Employee, Shipper } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class ShipperService {

  private urlService = 'Shipper/';

  constructor(
    protected http: HttpClient,
    @Inject(BACKEND_URL) private urlBack: string
  ) { }

  public getShippers(): Observable<Shipper[]> {
    return this.http.get<Shipper[]>(`${this.urlBack}${this.urlService}`,
      {
        headers: new HttpHeaders()
      });
  }
}