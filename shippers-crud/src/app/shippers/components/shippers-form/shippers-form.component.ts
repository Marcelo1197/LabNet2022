import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ShippersRequest } from 'src/app/models/shippers/shippersRequest';
import { ApiCrudService } from '../../services/api-crud.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-shippers-form',
  templateUrl: './shippers-form.component.html',
  styleUrls: ['./shippers-form.component.css']
})
export class ShippersFormComponent implements OnInit {

  form : FormGroup = new FormGroup({});
  constructor(
    private fb : FormBuilder,
    private apiService: ApiCrudService,
    private alertService: NgToastService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      companyName : [null, Validators.compose([
        Validators.required,
        Validators.maxLength(40),
        Validators.pattern("^[\ a-zA-Z]+$"),
      ])],
      phone : [null, Validators.compose([
        Validators.required,
        Validators.maxLength(24)
      ])],
    });
  }

  onSubmit(): void {
    console.log("onSubmit()!");
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
      },
      error: err => {
        this.alertService.error({
          detail: "Ups hubo un problema!",
          summary: `${err.error.ErrorMessage}`
        });
      },
    });
  }
}
