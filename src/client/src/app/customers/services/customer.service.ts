import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, tap } from 'rxjs';
import { NewCustomerDto } from '../models/new-customer-dto';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private baseUrl = 'customers';
  private customerDtos:Customer[] = [];
  private customersSubject: ReplaySubject<Customer[]> = new ReplaySubject<Customer[]>(1);

  public customers$: Observable<Customer[]> = this.customersSubject.asObservable();



  constructor(private http: HttpClient) {
    this.getCustomers().subscribe((res:Customer[])=>{
      this.customersSubject.next(res);
      this.customerDtos = [...res];
    });
  }

  private getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl);
  }

  getCustomer(id: string): Observable<Customer> {
    return this.http.get<Customer>(`${this.baseUrl}/${id}`);
  }

  createCustomer(newCustomer: NewCustomerDto): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl, newCustomer).pipe(tap(res=>{
      this.customerDtos = [res,...this.customerDtos];
      this.customersSubject.next(this.customerDtos);

    }));
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`).pipe(tap(_=>{
      this.customerDtos = this.customerDtos.filter(x=> x.id !== id);
      this.customersSubject.next(this.customerDtos);
    }));
  }
}
