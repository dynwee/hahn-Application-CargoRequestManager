import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Terminal } from '../models/ui-models/terminal.model';
import { TerminalService } from '../services/terminal.service';

export interface DialogData {
  changeRequest: string;
}

@Component({
  selector: 'app-terminal',
  templateUrl: './terminal.component.html',
  styleUrls: ['./terminal.component.css']
})
export class TerminalComponent implements OnInit {
  terminal: Terminal[] = [];
  displayedColumns: string[] = ['terminalName', 'terminalContactNo', 'emailAddress', 'isActive', 'view'];
  dataSource: MatTableDataSource<Terminal> = new MatTableDataSource<Terminal>();
  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;
  filterString = '';
  changeRequest = '';
  cargoRequestId = 0;

  constructor(private terminalService: TerminalService, private _snackBar: MatSnackBar
    , private router: Router) { }

  ngOnInit(): void {
    this.terminalService.getTerminals()
      .subscribe(
        (successResponse) => {
          this.terminal = successResponse;
          console.log(successResponse);
          this.dataSource = new MatTableDataSource<Terminal>(this.terminal);

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

  filterterminal() {
    this.dataSource.filter = this.filterString.trim().toLowerCase();
  }
}

