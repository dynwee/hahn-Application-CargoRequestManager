import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CargoRequestDetail } from 'src/app/models/ui-models/cargorequestdetail.model';
import { Terminal } from 'src/app/models/ui-models/terminal.model';
import { TerminalService } from 'src/app/services/terminal.service';
import { CargorequestService } from '../../services/cargorequest.service';

@Component({
  selector: 'app-view-requestdetail',
  templateUrl: './view-requestdetail.component.html',
  styleUrls: ['./view-requestdetail.component.css']
})
export class ViewRequestdetailComponent implements OnInit {

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
    , private readonly route: ActivatedRoute,private readonly terminalService: TerminalService) { }

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

}
