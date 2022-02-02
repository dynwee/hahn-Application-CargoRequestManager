import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CargoRequestDetail } from 'src/app/models/ui-models/cargorequestdetail.model';
import { Terminal } from 'src/app/models/ui-models/terminal.model';
import { TerminalService } from 'src/app/services/terminal.service';
import { CargorequestService } from '../../services/cargorequest.service';

@Component({
  selector: 'app-view-requestdetail',
  templateUrl: './add-requestdetail.component.html',
  styleUrls: ['./add-requestdetail.component.css']
})
export class AddRequestdetailComponent implements OnInit {

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
  @ViewChild('cargorequestDetailForm') cargorequestDetailForm?: NgForm

  constructor(private readonly cargorequestdetail: CargorequestService
    , private readonly route: ActivatedRoute, private readonly terminalService: TerminalService
  ,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
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

  onAdd(): void {
    if(this.cargorequestDetailForm?.form.valid)
    {
          this.cargorequestdetail.addCargoRequest(this.cargorequestdetails)
          .subscribe(
            (successResponse) => {
              //console.log("updated successful")
              this._snackBar.open('Cargo Request added successfully', undefined, {
                duration: 2000
              });
              this.router.navigateByUrl('/cargorequest');
            },
            (errorResponse) =>{
              this._snackBar.open('Cargo request addition Failed, Please contact the admin', undefined, {
                duration: 8000
              });
            }
        )
      }else{
        this._snackBar.open('Some required fields are missing, Please make sure all required field is populated', undefined, {
          duration: 2000
        });
      }
  }

}
