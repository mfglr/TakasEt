import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserImageService {

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  addUserImage(formData : FormData) : Observable<NoContentResponse>{
    return this.httpClient.post<NoContentResponse>("user-image/add-user-image",formData);
  }

  getUserImage(id : number) : Observable<string>{
    return this.httpClient.getBlob(`user-image/get-user-image/${id}`)
  }



}
