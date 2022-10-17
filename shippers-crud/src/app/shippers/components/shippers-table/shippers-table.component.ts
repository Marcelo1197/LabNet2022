import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Shippers } from 'src/app/models/shippers/shippers';
import { ApiCrudService } from '../../services/api-crud.service';
import { ShippersDialogComponent } from '../shippers-dialog/shippers-dialog.component';
import { ToastEvokeService } from '@costlydeveloper/ngx-awesome-popup';

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
    private alertServiceT: ToastEvokeService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getShippers();
  }

  getShippers() {
    this.apiService.getShippers().subscribe({
      next: res => {
        this.shippersList = res;
      }
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
        this.alertServiceT.warning("Shipper eliminado", `Se eliminó con éxito el Shipper #${id}`);
        this.getShippers();
      },
      error: err => {
        let errorMessage = err.error.ErrorMessage ? err.error.ErrorMessage : "Hay problemas de conexión. Intenta más tarde.";
        this.alertServiceT.danger("Ups, hubo un error!", errorMessage);
      }
    });
  }

}
