import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CustomersCreateComponent } from './customers-create/customers-create.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent {

  constructor(private dialog: MatDialog) {
  }
  createNewCustomer(): void {
    this.dialog.open(CustomersCreateComponent, {
      width: "400px"
    });
  }
}
