import { Component } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { Observable, map } from 'rxjs';
import { Customer } from '../models/customer';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent {
  displayedColumns: string[] = ['firstName', 'lastName','edit'];

  dataSource = new MatTableDataSource<Customer>();
  customers$: Observable<MatTableDataSource<Customer>> ;

  constructor(private customerService: CustomerService,
              private snackBar: MatSnackBar    ) {
    this.customers$ = customerService.customers$.pipe(map(x=>new MatTableDataSource<Customer>(x)));
  }

  delete(id: string):void{
    this.customerService.delete(id).subscribe(res=>{
      this.snackBar.open('Customer deleted!', 'Dismiss', { duration: 3000 });
    });
  }

}
