import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/responses/login-response';
import { UserResponse } from '../models/responses/user-response';
import { AppHttpClientService } from './app-http-client.service';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private appHttpClient: AppHttpClientService,
    ) {
  }

  getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`user/get-user-by-username/${userName}`);
  }

  getUser(userId : string) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`user/get-user/${userId}`);
  }

  addProfileImage(formData:FormData) : Observable<NoContentResponse> {
    return this.appHttpClient.post<NoContentResponse>('user/add-profile-image',formData);
  }
}