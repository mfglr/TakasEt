import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { LoginResponse } from '../models/login-response';
import { Observable } from 'rxjs';
import { UserResponse } from '../models/user-response';
import { AccessTokenProviderService } from './access-token-provider.service';
import { AppResponse } from '../models/app-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl : string = "http://localhost:7188/api"
  constructor(
    private httpClient: HttpClient,
    private accessTokenProvider: AccessTokenProviderService) {
  }

  public login(email : string,password : string): Observable<AppResponse<LoginResponse>>{
    return this.httpClient.post<AppResponse<LoginResponse>>(
      `${this.baseUrl}/login`,
      {email : email,password : password}
    );
  }

  public getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.httpClient.get<UserResponse>(
      `${this.baseUrl}/get-user-by-username/${userName}`,
      {headers : this.accessTokenProvider.httpHeaders}
    );
  }

}
