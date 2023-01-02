import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { CustomersComponent } from './customers.component';
import { CustomersCreateComponent } from './customers-create/customers-create.component';

import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { CustomersListComponent } from './customers-list/customers-list.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';


@NgModule({
  declarations: [
    CustomersComponent,
    CustomersCreateComponent,
    CustomersListComponent
  ],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    MatPaginatorModule,
    MatTableModule
  ]
})
export class CustomersModule { }
