import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Shippers } from 'src/app/models/shippers/shippers';
import { DialogEditComponent } from 'src/app/shippers/templates/dialog-edit.component';
import { ApiCrudService } from '../../services/api-crud.service';
import { NgToastService } from 'ng-angular-popup';
import { ShippersDialogComponent } from '../shippers-dialog/shippers-dialog.component';

@Component({
  selector: 'app-shippers-table',
  templateUrl: './shippers-table.component.html',
  styleUrls: ['./shippers-table.component.css']
})
export class ShippersTableComponent implements OnInit {
  shippersList!: Shippers[];
  columnsToDisplay = ['ShipperID', 'CompanyName', 'Phone', 'editShipper', 'deleteShipper'];

  constructor(
    private apiService: ApiCrudService,
    private alertService: NgToastService,
    private cdRef:ChangeDetectorRef,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getShippers();
  }

  getShippers() {
    this.apiService.getShippers().subscribe({
      next: res => {
        this.shippersList = res;
        this.cdRef.detectChanges();
      },
      error: err => console.log(err) //TODO: reemplazar cl
    });
  }

  openAddDialog() {
    this.dialog.open(ShippersDialogComponent, {
      data: {
        isAddDialog: true,
      }
    })
    .afterClosed().subscribe(() =>  this.getShippers());
  }

  openEditDialog(shipperToEdit: Shippers) {
    this.dialog.open(ShippersDialogComponent, {
      data: {
        ShippersModel: shipperToEdit,
        isAddDialog: false
      }
    })
    .afterClosed().subscribe(() =>  this.getShippers());
  }

  deleteShipper(id: number) {
    this.apiService.deleteShipper(id).subscribe({
      next: () => {
        this.alertService.info({
          detail: "Shipper eliminado",
          summary: `Se eliminó con éxito el Shipper ${id}`,
          duration: 3000
        });
        this.getShippers();
      },
      error: err => {
        this.alertService.error({
          detail: "Ups, hubo un error!",
          summary: `${err.error.ErrorMessage}`, //TODO: mostrar en otra pagina el detalle del error
          duration: 4500
        });
      }
    });
  }

}
