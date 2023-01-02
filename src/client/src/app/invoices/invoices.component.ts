import { Invoice } from './models/invoice';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InvoicesCreateComponent } from './invoices-create/invoices-create.component';
import { InvoiceEditComponent } from './invoice-edit/invoice-edit.component';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.scss']
})
export class InvoicesComponent {
  constructor(private dialog: MatDialog) {

  }

  createNewInvoice(): void {
    this.dialog.open(InvoicesCreateComponent, {
      width: "400px"
    }).afterClosed().subscribe(res=>{this.editInvoice(res)});
  }

  editInvoice(invoice?:Invoice): void {
    if(!invoice) return;
    this.dialog.open(InvoiceEditComponent, {
      width: '400px',
      data: invoice
    });
  }
}
