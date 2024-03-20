import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NativeHttpClientService } from 'src/app/services/native-http-client.service';
import { LoginResponse } from '../models/login-response';
import { AppResponse } from 'src/app/models/responses/app-response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private readonly baseUrl = environment.authService;

  constructor(
    private httpClient : NativeHttpClientService
  ) {}

  login(email : string,password : string): Observable<AppResponse<LoginResponse>>{
    return this.httpClient.post<LoginResponse>(
      `${this.baseUrl}/login/loginbyemail`,
      {
        email : email,
        password : password,
        timeZone : Intl.DateTimeFormat().resolvedOptions().timeZone,
        offset : new Date().getTimezoneOffset()
      });
  }

  loginByRefreshToken(userId : string,token : string): Observable<AppResponse<LoginResponse>>{
    return this.httpClient.post<LoginResponse>(
      `${this.baseUrl}/login/LoginByRefreshToken`,
      {
        userId : userId,
        token : token,
        timeZone : Intl.DateTimeFormat().resolvedOptions().timeZone,
        offset : new Date().getTimezoneOffset()
      }
    );
  }

  loginByFacebook() : Observable<AppResponse<LoginResponse>>{
    return this.httpClient.get<LoginResponse>(`${this.baseUrl}/login/LoginByFacebook`)
  }

}
