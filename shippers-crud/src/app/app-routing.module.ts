import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersTableComponent } from './shippers/components/shippers-table/shippers-table.component';

const routes: Routes = [
  {
    path: "",
    component: ShippersTableComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
