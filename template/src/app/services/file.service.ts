import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { AppHttpClientService } from './app-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private appHttpClient : AppHttpClientService){}

  public upload( formData : FormData ) : Observable<NoContentResponse> {
    return this.appHttpClient.post<NoContentResponse>("file/upload",formData);
  }

}
