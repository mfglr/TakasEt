import { Injectable } from '@angular/core';
import { Observable, first, from, mergeMap } from 'rxjs';
import { LoginResponse } from '../models/responses/login-response';
import { UserResponse } from '../models/responses/user-response';
import { AppHttpClientService } from './app-http-client.service';
import { NoContentResponse } from '../models/responses/no-content-response';
import { AppFileService } from './app-file.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private appHttpClient: AppHttpClientService,
    private appFileService : AppFileService
    ) {
  }

  login(email : string,password : string): Observable<LoginResponse>{
    return this.appHttpClient.post<LoginResponse>("login",{email : email,password : password});
  }

  getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`user/get-user-by-username/${userName}`);
  }

  addProfileImage(formData:FormData) : Observable<NoContentResponse> {
    return this.appHttpClient.post<NoContentResponse>('user/add-profile-image',formData);
  }
}
