import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {
  private readonly baseUrl = 'invoices';

  constructor(private http: HttpClient) {}

  getInvoices(): Observable<InvoiceDto[]> {
    return this.http.get<InvoiceDto[]>(this.baseUrl);
  }

  getInvoice(id: string): Observable<InvoiceDto> {
    return this.http.get<InvoiceDto>(`${this.baseUrl}/${id}`);
  }

  createInvoice(invoice: InvoiceDto): Observable<InvoiceDto> {
    return this.http.post<InvoiceDto>(this.baseUrl, invoice);
  }

  updateInvoice(invoice: InvoiceDto): Observable<InvoiceDto> {
    return this.http.put<InvoiceDto>(`${this.baseUrl}/${invoice.id}`, invoice);
  }

  deleteInvoice(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
