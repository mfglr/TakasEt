import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileImageService {

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  addProfileImage(formData : FormData) : Observable<NoContentResponse>{
    return this.httpClient.post<NoContentResponse>("profile-image/add-profile-image",formData);
  }

}
