import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Terminal } from '../models/api-models/terminal.model';

@Injectable({
  providedIn: 'root'
})
export class TerminalService {

  private baseApiUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getTerminals(): Observable<Terminal[]> {
    return this.httpClient.get<Terminal[]>(this.baseApiUrl + '/Terminal')
  }

  getTerminal(terminalId:number): Observable<Terminal> {
    return this.httpClient.get<Terminal>(this.baseApiUrl + '/Terminal/' + terminalId);
  }

  addTerminal(terminalModel: Terminal) :Observable<any>{

    const addTerminal: Terminal = {
      id: terminalModel.id,
      terminalName: terminalModel.terminalName,
      terminalAddress: terminalModel.terminalAddress,
      terminalContactNo: terminalModel.terminalContactNo,
      emailAddress: terminalModel.emailAddress,
      websiteAddress: terminalModel.websiteAddress,
      isActive: terminalModel.isActive
    }

    return this.httpClient.post<any>(this.baseApiUrl + '/Terminal', addTerminal);

  }

  updateTerminal(terminalModel: Terminal) {

    const updateTerminal: Terminal = {
      id: terminalModel.id,
      terminalName: terminalModel.terminalName,
      terminalAddress: terminalModel.terminalAddress,
      terminalContactNo: terminalModel.terminalContactNo,
      emailAddress: terminalModel.emailAddress,
      websiteAddress: terminalModel.websiteAddress,
      isActive: Boolean(terminalModel.isActive)
    }
    return this.httpClient.put<any>(this.baseApiUrl + '/Terminal', updateTerminal);


  }

  deleteTerminal(requestId: number): Observable<any> {

    return this.httpClient.delete<any>(this.baseApiUrl + '/Terminal/' + requestId);

  }

}
