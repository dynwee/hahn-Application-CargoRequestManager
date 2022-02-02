import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddRequestdetailComponent } from './cargorequest/add-requestdetail/add-requestdetail.component';
import { CargorequestComponent } from './cargorequest/cargorequest.component';
import { DeleteRequestdetailComponent } from './cargorequest/delete-requestdetail/delete-requestdetail.component';
import { EditRequestdetailComponent } from './cargorequest/edit-requestdetail/edit-requestdetail.component';
import { ViewRequestdetailComponent } from './cargorequest/view-requestdetail/view-requestdetail.component';
import { AddTerminalComponent } from './terminal/add-terminal/add-terminal.component';
import { TerminalComponent } from './terminal/terminal.component';
import { ViewTerminalComponent } from './terminal/view-terminal/view-terminal.component';
import { AddVehicletypeComponent } from './vehicletype/add-vehicletype/add-vehicletype.component';
import { VehicletypeComponent } from './vehicletype/vehicletype.component';
import { ViewVehicletypeComponent } from './vehicletype/view-vehicletype/view-vehicletype.component';

const routes: Routes = [
  {
    path: '',
    component:CargorequestComponent
  },
  {
    path: 'cargorequest',
    component:CargorequestComponent
  },
  {
    path: 'cargorequest/:id',
    component:EditRequestdetailComponent
  },
  {
    path: 'viewcargorequest/:id',
    component:ViewRequestdetailComponent
  },
  {
    path: 'deletecargorequest/:id',
    component:DeleteRequestdetailComponent
  },
  {
    path: 'addcargorequest',
    component:AddRequestdetailComponent
  },
  {
    path: 'terminal',
    component:TerminalComponent
  },
  {
    path: 'addterminal',
    component:AddTerminalComponent
  },
  {
    path: 'viewterminal/:id',
    component:ViewTerminalComponent
  },
  {
    path: 'editterminal/:id',
    component:ViewRequestdetailComponent
  },
  {
    path: 'vehicletype',
    component:VehicletypeComponent
  },
  {
    path: 'addvehicletype',
    component:AddVehicletypeComponent
  },
  {
    path: 'viewvehicletype/:id',
    component:ViewVehicletypeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
