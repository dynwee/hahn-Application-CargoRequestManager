import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleType } from 'src/app/models/ui-models/vehicletype.model';
import { VehicleTypeService } from 'src/app/services/vehicletype.service';

@Component({
  selector: 'app-view-vehicletype',
  templateUrl: './view-vehicletype.component.html',
  styleUrls: ['./view-vehicletype.component.css']
})
export class ViewVehicletypeComponent implements OnInit {

  vehicleTypeId: string | null | undefined;
  vehicleTypeModel: VehicleType = {
      id: 0,
      vehicleTypeName: '',
      isActive: true

  }

  constructor(private readonly route: ActivatedRoute, private readonly vehicleTypeService: VehicleTypeService
    ,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.vehicleTypeId = params.get('id');

        if (this.vehicleTypeId) {
          this.vehicleTypeService.getVehicleType(Number(this.vehicleTypeId))
            .subscribe(
              (successResponse) => {
                this.vehicleTypeModel = successResponse;
              },
              (errorResponse) => {
                console.log(errorResponse);
              }

          )
        }
      }
    )
  }

  onSave(): void {
    console.log(this.vehicleTypeModel);
    this.vehicleTypeService.updateVehicleType(this.vehicleTypeModel)
    .subscribe(
      (successResponse) => {
        this._snackBar.open('new vehicle Updated successfully', undefined, {
          duration: 2000
        });
        this.router.navigateByUrl('/vehicletype');
      },
      (errorResponse) =>{
        this._snackBar.open('could not update a existing vehicle, Please contact the admin', undefined, {
          duration: 2000
        });
      }
  )
}

onDelete(): void {
    this.vehicleTypeService.deleteVehicleType(this.vehicleTypeModel.id)
    .subscribe(
      (successResponse) => {
        this._snackBar.open('Vehicle deleted successfully', undefined, {
          duration: 2000
        });
        this.router.navigateByUrl('/vehicletype');
      },
      (errorResponse) =>{
        this._snackBar.open('Could not delete Request, Please contact the admin', undefined, {
          duration: 2000
        });
      }
  )
}

}
