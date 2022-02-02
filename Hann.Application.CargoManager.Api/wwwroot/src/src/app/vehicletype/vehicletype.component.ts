import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { VehicleType } from '../models/ui-models/vehicletype.model';
import { VehicleTypeService } from '../services/vehicletype.service';

@Component({
  selector: 'app-vehicletype',
  templateUrl: './vehicletype.component.html',
  styleUrls: ['./vehicletype.component.css']
})
export class VehicletypeComponent implements OnInit {

  vehicletype: VehicleType[] = [];
  displayedColumns: string[] = ['vehicleTypeName',  'isActive', 'view'];
  dataSource: MatTableDataSource<VehicleType> = new MatTableDataSource<VehicleType>();
  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;
  filterString = '';


  constructor(private vehicletypeService: VehicleTypeService, private _snackBar: MatSnackBar
    , private router: Router) { }

  ngOnInit(): void {
    this.vehicletypeService.getVehicleTypes()
    .subscribe(
      (successResponse) => {
        this.vehicletype = successResponse;
        this.dataSource = new MatTableDataSource<VehicleType>(this.vehicletype);

        if (this.matPaginator) {
          this.dataSource.paginator = this.matPaginator;
        }

        if (this.matSort) {
          this.dataSource.sort = this.matSort;
        }
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    )
  }

  filtervehicletype() {
    this.dataSource.filter = this.filterString.trim().toLowerCase();
  }


}
