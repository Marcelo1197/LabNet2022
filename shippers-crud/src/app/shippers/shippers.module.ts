import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';

import { CustomErrorMatcher } from './utils/custom-error-matcher';
import { ErrorStateMatcher } from '@angular/material/core';
import { ShippersTableComponent } from './components/shippers-table/shippers-table.component';
import { ShippersDialogComponent } from './components/shippers-dialog/shippers-dialog.component';


@NgModule({
  declarations: [
    ShippersTableComponent,
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
  ],
  providers: [
    { provide: ErrorStateMatcher, useClass: CustomErrorMatcher},
  ],
})
export class ShippersModule { }
