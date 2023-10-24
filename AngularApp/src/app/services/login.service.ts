import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/responses/login-response';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  login(email : string,password : string): Observable<LoginResponse>{
    return this.appHttpClient.post<LoginResponse>("login",{email : email,password : password});
  }

  loginByRefreshToken(refreshToken : string): Observable<LoginResponse>{
    return this.appHttpClient.post<LoginResponse>("login-by-refresh-token",{refreshToken : refreshToken});
  }

}
