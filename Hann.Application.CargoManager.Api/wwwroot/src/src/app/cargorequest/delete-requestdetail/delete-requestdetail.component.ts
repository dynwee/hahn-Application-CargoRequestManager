import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CargoRequestDetail } from 'src/app/models/ui-models/cargorequestdetail.model';
import { CargorequestService } from '../../services/cargorequest.service';

@Component({
  selector: 'app-view-requestdetail',
  templateUrl: './delete-requestdetail.component.html',
  styleUrls: ['./delete-requestdetail.component.css']
})
export class DeleteRequestdetailComponent implements OnInit {

  cargoRequestId: string | null | undefined;
  cargorequestdetails: CargoRequestDetail = {
    id: 0,
  customerName: '',
  deliveryDate: '',
  deliveryTerminal: {
      id: 0,
      terminalName: '',
      terminalAddress: '',
      terminalContactNo: '',
      emailAddress: '',
      websiteAddress: '',
      isActive: true,
      status:''
  },
  deliveryTerminalId: 0,
  dropOffDate: '',
  dropOffTerminal: {
    id: 0,
    terminalName: '',
    terminalAddress: '',
    terminalContactNo: '',
    emailAddress: '',
    websiteAddress: '',
    isActive: true,
    status:''
  },
  dropOffTerminalId: 0,
  emailAddress: '',
  estimatedWeight: '',
  itemDescription: '',
  itemSummary: '',
  phoneNumber: '',
  status:''
  }


  constructor(private readonly cargorequestdetail: CargorequestService
    , private readonly route: ActivatedRoute,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.cargoRequestId = params.get('id');

        if (this.cargoRequestId) {
          this.cargorequestdetail.getCargoRequestDetails(Number(this.cargoRequestId))
            .subscribe(
              (successResponse) => {
                this.cargorequestdetails = successResponse;
              },
              (errorResponse) => {
                console.log(errorResponse);
              }

          )
        }
      }
    )

  }

  onDelete(): void {
     this.cargorequestdetail.deleteCargoRequest(this.cargorequestdetails.id)
       .subscribe(
         (successResponse) => {
           this._snackBar.open('Cargo Request delete successfully', undefined, {
             duration: 2000
           });
           this.router.navigateByUrl('/cargorequest');
         },
         (errorResponse) =>{
           this._snackBar.open('Could not delete Request, Please contact the admin', undefined, {
             duration: 2000
           });
         }
     )


   }

}
