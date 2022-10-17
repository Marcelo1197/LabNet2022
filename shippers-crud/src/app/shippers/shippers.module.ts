import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShippersFormComponent } from './components/shippers-form/shippers-form.component';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';

import {NgToastModule} from 'ng-angular-popup';

import { CustomErrorMatcher } from './utils/custom-error-matcher';
import { ErrorStateMatcher } from '@angular/material/core';
import { ShippersTableComponent } from './components/shippers-table/shippers-table.component';
import { DialogEditComponent } from './templates/dialog-edit.component';
import { ShippersDialogComponent } from './components/shippers-dialog/shippers-dialog.component';


@NgModule({
  declarations: [
    ShippersFormComponent,
    ShippersTableComponent,
    DialogEditComponent,
    ShippersDialogComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MatCardModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule,
    NgToastModule
  ],
  providers: [
    { provide: ErrorStateMatcher, useClass: CustomErrorMatcher},
  ],
})
export class ShippersModule { }
