import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShippersRequest } from 'src/app/models/shippers/shippersRequest';
import { Shippers } from '../../../models/shippers/shippers';
import { ApiCrudService } from '../../services/api-crud.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-shippers-dialog',
  templateUrl: './shippers-dialog.component.html',
  styleUrls: ['./shippers-dialog.component.css']
})
export class ShippersDialogComponent implements OnInit {
  form!: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public dataInjected: { ShippersModel: Shippers, isAddDialog: boolean, isEditDialog: boolean },
    private fb: FormBuilder,
    private apiService: ApiCrudService,
    private dialog: MatDialog,
    private alertService: NgToastService,
  ){ }

  ngOnInit() {
    let isAddForm = this.dataInjected.isAddDialog;
    let companyNameToEdit = isAddForm ? "" : this.dataInjected.ShippersModel.CompanyName;
    let phoneToEdit = isAddForm ? "" : this.dataInjected.ShippersModel.Phone;

    this.form = this.fb.group({
      companyName: [(isAddForm ? null : companyNameToEdit), Validators.compose([ //FIX: (isAddForm ? null : companyNameToEdit)
        Validators.required,
        Validators.maxLength(40),
        Validators.pattern("^[\ a-zA-Z]+$"),
      ])],
      phone: [(isAddForm ? null : phoneToEdit), Validators.compose([ //FIX: (isAddForm ? null : phoneToEdit)
        Validators.required,
        Validators.maxLength(24)
      ])],
    });
  }

  addShipper() {
    let companyName = this.form.controls["companyName"].value;
    let phone = this.form.controls["phone"].value;
    let newShipper = new ShippersRequest();
    newShipper.CompanyName = companyName;
    newShipper.Phone = phone;
    this.apiService.addShippers(newShipper).subscribe({
      next: (res) => {
        this.alertService.success({
          detail: "Shipper creado!",
          summary: "Se creó el Shipper exitosamente"
        });
        this.closeDialog();
      },
      error: err => {
        this.alertService.error({
          detail: "Ups hubo un problema!",
          summary: `${err.error.ErrorMessage}`
        });
        this.closeDialog();
      },
    });
  }

  editShipper(id: number) {
    let shipperEdited = new Shippers();
    shipperEdited.ShipperID = this.dataInjected.ShippersModel.ShipperID;
    shipperEdited.CompanyName = this.form.controls["companyName"].value;
    shipperEdited.Phone = this.form.controls["phone"].value;

    this.apiService.updateShippers(shipperEdited).subscribe({
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
