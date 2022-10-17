import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShippersRequest } from 'src/app/models/shippers/shippersRequest';
import { Shippers } from '../../models/shippers/shippers';
import { ApiCrudService } from '../services/api-crud.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'dialog-data-example-dialog',
  templateUrl: 'dialog-edit.component.html',
})
export class DialogEditComponent implements OnInit {

  form!: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public dataInjected: Shippers,
    private fb: FormBuilder,
    private service: ApiCrudService,
    private dialog: MatDialog,
    private alertService: NgToastService,
  ){}

  ngOnInit() {
    this.form = this.fb.group({
      companyName: [this.dataInjected.CompanyName, Validators.compose([
        Validators.required,
        Validators.maxLength(40),
        Validators.pattern("^[\ a-zA-Z]+$"),
      ])],
      phone: [this.dataInjected.Phone, Validators.compose([
        Validators.required,
        Validators.maxLength(24)
      ])],
    });
  }

  editShipper(id: number) {
    let shipperEdited = new Shippers();
    shipperEdited.ShipperID = this.dataInjected.ShipperID;
    shipperEdited.CompanyName = this.form.controls["companyName"].value;
    shipperEdited.Phone = this.form.controls["phone"].value;

    this.service.updateShippers(shipperEdited).subscribe({
      next: () => {
        this.alertService.success({
          detail: "Shipper actualizado!",
          summary: `Se actualizó el Shipper ${shipperEdited.ShipperID} con éxito!`
        });
        this.closeDialog();
      },
      error: err => {
        this.alertService.error({
          detail: "Ups hubo un error!",
          summary: "No pudimos actualizar el shipper :(" //TODO: mostrar en otra pagina el detalle del error
        });
        this.closeDialog();
      }
    });
  }

  closeDialog() {
    this.dialog.closeAll();
  }
}
