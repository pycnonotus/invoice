import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';

import { InvoicesRoutingModule } from './invoices-routing.module';
import { InvoicesComponent } from './invoices.component';
import { InvoicesCollectionComponent } from './invoices-collection/invoices-collection.component';
import { InvoicesCreateComponent } from './invoices-create/invoices-create.component';
import { StatusNamePipe } from './pipes/status-name.pipe';
import { InvoiceEditComponent } from './invoice-edit/invoice-edit.component';


@NgModule({
  declarations: [
    InvoicesComponent,
    InvoicesCollectionComponent,
    InvoicesCreateComponent,
    StatusNamePipe,
    InvoiceEditComponent
  ],
  imports: [
    CommonModule,
    InvoicesRoutingModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule
  ]
})
export class InvoicesModule { }
