import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomerService } from '../services/customer.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  templateUrl: './customers-create.component.html',
  styleUrls: ['./customers-create.component.scss']
})
export class CustomersCreateComponent {
  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private customerService:CustomerService,
    public dialogRef: MatDialogRef<CustomersCreateComponent>
    ) {
    this.createForm();
  }

  createForm() {
    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
    });
  }

  onSubmit() {
    var formValue = this.form.value;

    this.customerService.createCustomer(formValue).subscribe(res=>{
      this.snackBar.open('Customer added!', 'Dismiss', { duration: 3000 });
      this.dialogRef.close();
    });
  }
}
