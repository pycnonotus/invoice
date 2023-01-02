import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject, tap } from 'rxjs';
import { Invoice } from '../models/invoice';
import { NewInvoice } from '../models/new-invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {
  private readonly baseUrl = 'invoices';

  private readonly invoicesSubject  = new ReplaySubject<Invoice[]>(1);
  public readonly invoices$:Observable<Invoice[]> = this.invoicesSubject.asObservable();
  private invoices: Invoice[] = [];

  constructor(private http: HttpClient) {
    this.getInvoices().subscribe();
  }

  private getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.baseUrl).pipe(tap(res=>{
      this.invoicesSubject.next(res);
      this.invoices = res;
    }));
  }

  getInvoice(id: string): Observable<Invoice> {
    return this.http.get<Invoice>(`${this.baseUrl}/${id}`);
  }

  createInvoice(invoice: NewInvoice): Observable<Invoice> {
    return this.http.post<Invoice>(this.baseUrl, invoice).pipe(tap(res=>{
      this.invoices = [res, ...this.invoices];
      this.invoicesSubject.next(this.invoices);
    }));
  }

  updateInvoice(invoice: Invoice): Observable<Invoice> {
    return this.http.put<Invoice>(`${this.baseUrl}/${invoice.id}`, invoice).pipe(tap(res=>{
        var index = this.invoices.findIndex(x=> x.id === invoice.id);
        this.invoices[index] = invoice;
        this.invoices = [...this.invoices]; //TO kick change tracking
        this.invoicesSubject.next(this.invoices);

    }));
  }

  deleteInvoice(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`).pipe(tap(res=>{
      this.invoices = this.invoices.filter(x=> x.id !== id);
      this.invoicesSubject.next(this.invoices);
    }));
  }
}
