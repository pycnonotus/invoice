import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { InvoicesService } from '../services/invoices-service.service';
import { Invoice } from '../models/invoice';
import { Observable, map } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { InvoiceEditComponent } from '../invoice-edit/invoice-edit.component';

@Component({
  selector: 'app-invoices-collection',
  templateUrl: './invoices-collection.component.html',
  styleUrls: ['./invoices-collection.component.scss'],
})
export class InvoicesCollectionComponent {

  displayedColumns: string[] = ['customer', 'creation', 'amount','status', 'edit'];
  public invoices$: Observable<MatTableDataSource<Invoice>>;

  constructor(private invoicesService: InvoicesService,private dialog: MatDialog) {
    this.invoices$ = invoicesService.invoices$.pipe(
      map((x) => new MatTableDataSource<Invoice>(x))
    );
  }

  delete(id: string){
    this.invoicesService.deleteInvoice(id).subscribe();
  }

  edit(invoice?: Invoice): void {
    if (!invoice) return;
    this.dialog.open(InvoiceEditComponent, {
      width: '400px',
      data: invoice
    });
  }
}
