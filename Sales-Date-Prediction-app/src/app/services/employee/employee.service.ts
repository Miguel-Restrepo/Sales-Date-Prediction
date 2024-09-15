import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BACKEND_URL } from '../../injection-tokens';
import { Employee } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {

  private urlService = 'Employee/';

  constructor(
    protected http: HttpClient,
    @Inject(BACKEND_URL) private urlBack: string
  ) { }

  public getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.urlBack}${this.urlService}`,
      {
        headers: new HttpHeaders()
      });
  }
}