import { CustomerService } from 'src/app/customers/services/customer.service';
import { Invoice } from './../models/invoice';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvoicesService } from '../services/invoices-service.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/customers/models/customer';
import { getTextOfJSDocComment } from 'typescript';

@Component({
  templateUrl: './invoice-edit.component.html',
  styleUrls: ['./invoice-edit.component.scss'],
})
export class InvoiceEditComponent {
  public readonly invoiceForm: FormGroup;
  public readonly customers$: Observable<Customer[]>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public readonly invoice: Invoice,
    private formBuilder: FormBuilder,
    private invoiceService: InvoicesService,
    private customerService: CustomerService,
    public dialogRef: MatDialogRef<InvoiceEditComponent>,

  ) {
    this.invoiceForm = this.formBuilder.group({
      customerId: [invoice.customer.id, Validators.required],
      amount: [invoice.amount, [Validators.required, Validators.min(0)]],
      status: [invoice.status, [Validators.required]],
    });

    this.customers$ = customerService.customers$;
  }
  submit(): void {
    if (!this.invoiceForm.valid) return;

    const updatedInvoice = {
      ...this.invoice,
      customerId: this.invoiceForm.get('customerId')!.value,
      amount: this.invoiceForm.get('amount')!.value,
      status: this.invoiceForm.get('status')!.value,
    };

    this.invoiceService.updateInvoice(updatedInvoice).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
