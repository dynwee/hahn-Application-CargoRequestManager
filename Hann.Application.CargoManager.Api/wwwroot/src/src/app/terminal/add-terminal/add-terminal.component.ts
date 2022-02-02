import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Terminal } from 'src/app/models/ui-models/terminal.model';
import { TerminalService } from 'src/app/services/terminal.service';

@Component({
  selector: 'app-add-terminal',
  templateUrl: './add-terminal.component.html',
  styleUrls: ['./add-terminal.component.css']
})
export class AddTerminalComponent implements OnInit {

  cargoRequestId: string | null | undefined;
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

  }

  onAdd(): void {
    console.log(this.terminalModel);
    this.terminalService.addTerminal(this.terminalModel)
    .subscribe(
      (successResponse) => {
        this._snackBar.open('new terminal added successfully', undefined, {
          duration: 2000
        });
        this.router.navigateByUrl('/terminal');
      },
      (errorResponse) =>{
        this._snackBar.open('could not create a new terminal, Please contact the admin', undefined, {
          duration: 2000
        });
      }
  )
  }

}
