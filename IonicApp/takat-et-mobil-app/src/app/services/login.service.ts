import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/responses/login-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  login(email : string,password : string): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>("login",{email : email,password : password});
  }

  loginByRefreshToken(refreshToken : string): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>("login-by-refresh-token",{refreshToken : refreshToken});
  }

}
