import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/customers/models/customer';
import { CustomerService } from 'src/app/customers/services/customer.service';
import { InvoicesService } from '../services/invoices-service.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  templateUrl: './invoices-create.component.html',
  styleUrls: ['./invoices-create.component.scss']
})

export class InvoicesCreateComponent {

  public readonly invoiceForm: FormGroup;
  public readonly customers$:  Observable<Customer[]> ;

  constructor(
    private formBuilder: FormBuilder,
    private invoicesService: InvoicesService,
    public dialogRef: MatDialogRef<InvoicesCreateComponent>,
    customerService: CustomerService) {

    this.invoiceForm = this.formBuilder.group({
      customerId: [null,Validators.required]
    });

    this.customers$ = customerService.customers$;
  }
  ngOnInit(): void {

  }

  submit():void{
    if(!this.invoiceForm.valid) return ;

    this.invoicesService.createInvoice(this.invoiceForm.value).subscribe((res) => {
      this.dialogRef.close(res);
    });

  }
}
