import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { NewCustomerDto } from '../models/new-customer-dto';
import { CustomerDto } from '../models/customer-dto';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private baseUrl = '/api/customers';
  private customersSubject: ReplaySubject<CustomerDto[]> = new ReplaySubject<CustomerDto[]>(1);

  public customersSubject$: Observable<CustomerDto[]> = this.customersSubject.asObservable();


  constructor(private http: HttpClient) { }

  getCustomers(): Observable<CustomerDto[]> {
    return this.http.get<CustomerDto[]>(this.baseUrl);
  }

  getCustomer(id: string): Observable<CustomerDto> {
    return this.http.get<CustomerDto>(`${this.baseUrl}/${id}`);
  }

  createCustomer(newCustomer: NewCustomerDto): Observable<CustomerDto> {
    return this.http.post<CustomerDto>(this.baseUrl, newCustomer);
  }

  deleteCustomer(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
