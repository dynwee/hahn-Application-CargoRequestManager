import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CargoRequestDetail } from 'src/app/models/ui-models/cargorequestdetail.model';
import { Terminal } from 'src/app/models/ui-models/terminal.model';
import { TerminalService } from 'src/app/services/terminal.service';
import { CargorequestService } from '../../services/cargorequest.service';

@Component({
  selector: 'app-view-requestdetail',
  templateUrl: './edit-requestdetail.component.html',
  styleUrls: ['./edit-requestdetail.component.css']
})
export class EditRequestdetailComponent implements OnInit {

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

  terminalList: Terminal[] = [];

  constructor(private readonly cargorequestdetail: CargorequestService
    , private readonly route: ActivatedRoute, private readonly terminalService: TerminalService
  ,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.cargoRequestId = params.get('id');

        if (this.cargoRequestId) {
          this.cargorequestdetail.getCargoRequestDetails(Number(this.cargoRequestId))
            .subscribe(
              (successResponse) => {
                this.cargorequestdetails = successResponse;
                console.log(successResponse);
              },
              (errorResponse) => {
                console.log(errorResponse);
              }

          );
          this.terminalService.getTerminals()
            .subscribe(
              (successResponse) => {
                this.terminalList = successResponse;
              },
              (errorResponse) => {
              console.log(errorResponse);
            }
          )
        }
      }
    )

  }

  onUpdate(): void {

   // console.log(this.cargorequestdetails);
    this.cargorequestdetail.updateCargoRequest(this.cargorequestdetails.id, this.cargorequestdetails)
      .subscribe(
        (successResponse) => {
          //console.log("updated successful")
          this._snackBar.open('Cargo Request updated successfully', undefined, {
            duration: 2000
          });
          this.router.navigateByUrl('/cargorequest');
        },
        (errorResponse) =>{
          this._snackBar.open('Cargo updated Failed, Please contact the admin', undefined, {
            duration: 2000
          });
        }
    )


  }

}
