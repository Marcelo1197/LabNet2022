import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShippersRequest } from 'src/app/models/shippers/shippersRequest';
import { Shippers } from '../../../models/shippers/shippers';
import { ApiCrudService } from '../../services/api-crud.service';
import { ToastEvokeService } from '@costlydeveloper/ngx-awesome-popup';

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
    private alertServiceT: ToastEvokeService,
  ){ }

  ngOnInit() {
    let isAddForm = this.dataInjected.isAddDialog;
    let companyNameToEdit = isAddForm ? "" : this.dataInjected.ShippersModel.CompanyName;
    let phoneToEdit = isAddForm ? "" : this.dataInjected.ShippersModel.Phone;

    this.form = this.fb.group({
      companyName: [(isAddForm ? null : companyNameToEdit), Validators.compose([
        Validators.required,
        Validators.maxLength(40),
        Validators.pattern("^[\ a-zA-Z]+$"),
      ])],
      phone: [(isAddForm ? null : phoneToEdit), Validators.compose([
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
        this.alertServiceT.success("Shipper creado!", `Se creó el Shipper ${newShipper.CompanyName} exitosamente`);
        this.closeDialog();
      },
      error: err => {
        this.alertServiceT.danger(
          "Ups hubo un problema!",
          `${err.error.ErrorMessage ? err.error.ErrorMessage : "Hay problemas de conexión. Intenta de nuevo más tarde."}`,
        );
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
        this.alertServiceT.success("Shipper actualizado!", `Se actualizó el Shipper ${shipperEdited.ShipperID} con éxito!`);
        this.closeDialog();
      },
      error: err => {
        let errorMessage = err.error.ErrorMessage ? err.error.ErrorMessage : "Hay problemas de conexión, intenta más tarde."
        this.alertServiceT.danger("Ups hubo un error!", errorMessage);
        this.closeDialog();
      }
    });
  }

  closeDialog() {
    this.dialog.closeAll();
  }
}
