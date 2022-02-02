import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Terminal } from 'src/app/models/ui-models/terminal.model';
import { TerminalService } from 'src/app/services/terminal.service';

@Component({
  selector: 'app-view-terminal',
  templateUrl: './view-terminal.component.html',
  styleUrls: ['./view-terminal.component.css']
})
export class ViewTerminalComponent implements OnInit {

  terminalId: string | null | undefined;
  terminalModel: Terminal = {
      id: 0,
      terminalName: '',
      terminalAddress: '',
      terminalContactNo: '',
      emailAddress: '',
      websiteAddress: '',
      isActive: true

  }

  constructor(private readonly route: ActivatedRoute, private readonly terminalService: TerminalService
  ,private _snackBar: MatSnackBar,private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.terminalId = params.get('id');

        if (this.terminalId) {
          this.terminalService.getTerminal(Number(this.terminalId))
            .subscribe(
              (successResponse) => {
                this.terminalModel = successResponse;
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
      console.log(this.terminalModel);
      this.terminalService.updateTerminal(this.terminalModel)
      .subscribe(
        (successResponse) => {
          this._snackBar.open('new terminal Updated successfully', undefined, {
            duration: 2000
          });
          this.router.navigateByUrl('/terminal');
        },
        (errorResponse) =>{
          this._snackBar.open('could not update a existing terminal, Please contact the admin', undefined, {
            duration: 2000
          });
        }
    )
  }

  onDelete(): void {
      this.terminalService.deleteTerminal(this.terminalModel.id)
      .subscribe(
        (successResponse) => {
          this._snackBar.open('Terminal deleted successfully', undefined, {
            duration: 2000
          });
          this.router.navigateByUrl('/terminal');
        },
        (errorResponse) =>{
          this._snackBar.open('Could not delete Request, Please contact the admin', undefined, {
            duration: 2000
          });
        }
    )
  }

}
