import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CargoRequest } from '../models/api-models/cargorequest.model';
import { CargoRequestDetail } from '../models/api-models/cargorequestdetail.model';
import { ChangeApproval } from '../models/api-models/changeapproval.model';
import { UpdateCargoRequest } from '../models/api-models/updatecargorequest.model';

@Injectable({
  providedIn: 'root'
})
export class CargorequestService {

  private baseApiUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getCargoRequest(): Observable<CargoRequest[]> {
    return this.httpClient.get<CargoRequest[]>(this.baseApiUrl + '/CargoRequest')
  }

  getCargoRequestDetails(cargoRequestId:number): Observable<CargoRequestDetail> {
    return this.httpClient.get<CargoRequestDetail>(this.baseApiUrl + '/CargoRequest/details/' + cargoRequestId);
  }

  updateCargoRequest(requestId: number, cargoRequestModel: CargoRequestDetail) {

    const updateCargoRequest: UpdateCargoRequest = {
      id: cargoRequestModel.id,
      status: "Pending",
      customerName: cargoRequestModel.customerName,
      emailAddress: cargoRequestModel.emailAddress,
      estimatedWeight: cargoRequestModel.estimatedWeight,
      phoneNumber: cargoRequestModel.phoneNumber,
      itemDescription: cargoRequestModel.itemDescription,
      itemSummary: cargoRequestModel.itemSummary,
      dropOffTerminalId: cargoRequestModel.dropOffTerminalId,
      deliveryDate: cargoRequestModel.deliveryDate,
      dropOffDate: cargoRequestModel.dropOffDate,
      deliveryTerminalId: cargoRequestModel.deliveryTerminalId
    }

    return this.httpClient.put<any>(this.baseApiUrl + '/CargoRequest/' + requestId, updateCargoRequest);


  }

  deleteCargoRequest(requestId: number): Observable<any> {

    return this.httpClient.delete<any>(this.baseApiUrl + '/CargoRequest/' + requestId);

  }

  changeCargoRequestApproval(requestId: number,changeValue:string): Observable<any> {

    const changeApproval: ChangeApproval = {
      id: requestId,
      status: changeValue,
    }

    return this.httpClient.patch<any>(this.baseApiUrl + '/CargoRequest/' + requestId,changeApproval);

  }

  addCargoRequest(cargoRequestModel: CargoRequestDetail) :Observable<any>{

    const updateCargoRequest: UpdateCargoRequest = {
      id: cargoRequestModel.id,
      status: "Pending",
      customerName: cargoRequestModel.customerName,
      emailAddress: cargoRequestModel.emailAddress,
      estimatedWeight: cargoRequestModel.estimatedWeight,
      phoneNumber: cargoRequestModel.phoneNumber,
      itemDescription: cargoRequestModel.itemDescription,
      itemSummary: cargoRequestModel.itemSummary,
      dropOffTerminalId: cargoRequestModel.dropOffTerminalId,
      deliveryDate: cargoRequestModel.deliveryDate,
      dropOffDate: cargoRequestModel.dropOffDate,
      deliveryTerminalId: cargoRequestModel.deliveryTerminalId
    }

    return this.httpClient.post<any>(this.baseApiUrl + '/CargoRequest', updateCargoRequest);


  }

}
