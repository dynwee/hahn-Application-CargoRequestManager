import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { CargoRequest } from '../models/ui-models/cargorequest.model';
import { CargorequestService } from '../services/cargorequest.service';

export interface DialogData {
  changeRequest: string;
}

@Component({
  selector: 'app-cargorequest',
  templateUrl: './cargorequest.component.html',
  styleUrls: ['./cargorequest.component.css']
})
export class CargorequestComponent implements OnInit {
  cargorequest: CargoRequest[] = [];
  displayedColumns: string[] = ['customerName', 'phoneNumber','emailAddress', 'estimatedWeight', 'deliveryDate','status','edit','view','delete','approve'];
  dataSource: MatTableDataSource<CargoRequest> = new MatTableDataSource<CargoRequest>();
  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;
  filterString = '';
  changeRequest='';
  cargoRequestId=0;

  constructor(private cargorequestService: CargorequestService, public dialog: MatDialog, private _snackBar: MatSnackBar
  ,private router: Router) { }

  ngOnInit(): void {
    //fetch cargo request
    this.cargorequestService.getCargoRequest()
      .subscribe(
        (successResponse) => {
          this.cargorequest = successResponse;
          this.dataSource = new MatTableDataSource<CargoRequest>(this.cargorequest);

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

  filtercargorequest() {
    this.dataSource.filter = this.filterString.trim().toLowerCase();
  }


  openDialog(requestedId: number): void {
    this.cargoRequestId = requestedId;
    const dialogRef = this.dialog.open(ChangeApprovalDialog, {
      width: '250px',
      data: {name: requestedId, animal: this.changeRequest},
    });

    dialogRef.afterClosed().subscribe(result => {
      this.changeRequest = result;
      if (this.changeRequest && this.cargoRequestId) {
        this.cargorequestService.changeCargoRequestApproval(this.cargoRequestId, this.changeRequest)
          .subscribe(
            (successResponse) => {
              this._snackBar.open('Cargo Request updated successfully', undefined, {
                duration: 2000
              });
              this.router.navigateByUrl('/');
            },
            (errorResponse) => {
              this._snackBar.open('Cargo updated Failed, Please contact the admin', undefined, {
                duration: 2000
              });
            }
          );
        }
    });
  }

  openCreateNewRequestDialog(): void {
    const dialogRef = this.dialog.open(ChangeApprovalDialog, {
      width: '250px',
      data: {name: '', animal: this.changeRequest},
    });

    dialogRef.afterClosed().subscribe(result => {
      this.changeRequest = result;
      if (this.changeRequest && this.cargoRequestId) {
        this.cargorequestService.changeCargoRequestApproval(this.cargoRequestId, this.changeRequest)
          .subscribe(
            (successResponse) => {
              this._snackBar.open('Cargo Request updated successfully', undefined, {
                duration: 2000
              });
              this.router.navigateByUrl('/');
            },
            (errorResponse) => {
              this._snackBar.open('Cargo updated Failed, Please contact the admin', undefined, {
                duration: 2000
              });
            }
          );
        }
    });
  }

}

@Component({
  selector: 'change-approval-dialog',
  templateUrl: 'change-approval-dialog.html',
})
export class ChangeApprovalDialog {
  constructor(
    public dialogRef: MatDialogRef<ChangeApprovalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}


