import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AccessTokenProviderService } from './access-token-provider.service';
import { FileResponse } from '../models/file-response';
import { NoContentResponse } from '../models/no-content-response';
import { AppResponse } from '../models/app-response';

@Injectable({
  providedIn: 'root'
})
export class BlobService {
  private baseUrl : string = "http://localhost:7188/api"
  constructor(
    private httpClient: HttpClient,
    private accessTokenProvider: AccessTokenProviderService) {
  }

  public upload(formData : FormData) : Observable<AppResponse<NoContentResponse>>{
    return this.httpClient.post<AppResponse<NoContentResponse>>( `${this.baseUrl}/`,formData);
  }
}
