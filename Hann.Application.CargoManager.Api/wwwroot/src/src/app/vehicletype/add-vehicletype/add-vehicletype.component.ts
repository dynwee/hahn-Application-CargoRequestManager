import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleType } from 'src/app/models/ui-models/vehicletype.model';
import { VehicleTypeService } from 'src/app/services/vehicletype.service';

@Component({
  selector: 'app-add-vehicletype',
  templateUrl: './add-vehicletype.component.html',
  styleUrls: ['./add-vehicletype.component.css']
})
export class AddVehicletypeComponent implements OnInit {

@ViewChild('vehicleTypeForm') vehicleTypeForm?: NgForm

  addVehicleTypeModel: VehicleType = {
    id: 0,
    vehicleTypeName: '',
    isActive: true

}
  constructor(private readonly route: ActivatedRoute, private readonly vehicletypeService: VehicleTypeService
    ,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
  }

  onAdd(): void {

        if(this.vehicleTypeForm?.form.valid)
        {
              this.vehicletypeService.addVehicleType(this.addVehicleTypeModel)
              .subscribe(
                (successResponse) => {
                  this._snackBar.open('new vehicle added successfully', undefined, {
                    duration: 2000
                  });
                  this.router.navigateByUrl('/vehicletype');
                },
                (errorResponse) =>{
                  this._snackBar.open('could not create a new vehicle, Please contact the admin', undefined, {
                    duration: 2000
                  });
                }
            )
        }else{
          this._snackBar.open('Some required fields are missing, Please make sure all required field is populated', undefined, {
            duration: 4000
          });
      }

    }

}
