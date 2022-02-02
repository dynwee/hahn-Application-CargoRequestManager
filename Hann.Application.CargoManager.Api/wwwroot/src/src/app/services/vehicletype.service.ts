import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { VehicleType } from '../models/api-models/vehicletype.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {

  private baseApiUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getVehicleTypes(): Observable<VehicleType[]> {
    return this.httpClient.get<VehicleType[]>(this.baseApiUrl + '/VehicleType')
  }

  getVehicleType(vehicleTypeId:number): Observable<VehicleType> {
    return this.httpClient.get<VehicleType>(this.baseApiUrl + '/VehicleType/' + vehicleTypeId);
  }

  addVehicleType(vehicleTypeModel: VehicleType) :Observable<any>{

    const addVehicleType: VehicleType = {
      id: vehicleTypeModel.id,
      vehicleTypeName: vehicleTypeModel.vehicleTypeName,
      isActive: vehicleTypeModel.isActive
    }

    return this.httpClient.post<any>(this.baseApiUrl + '/VehicleType', addVehicleType);

  }

  updateVehicleType(vehicleTypeModel: VehicleType) {

    const updateVehicleType: VehicleType = {
      id: vehicleTypeModel.id,
      vehicleTypeName: vehicleTypeModel.vehicleTypeName,
      isActive: Boolean(vehicleTypeModel.isActive)
    }
    return this.httpClient.put<any>(this.baseApiUrl + '/VehicleType', updateVehicleType);


  }

  deleteVehicleType(requestId: number): Observable<any> {

    return this.httpClient.delete<any>(this.baseApiUrl + '/VehicleType/' + requestId);

  }

}
