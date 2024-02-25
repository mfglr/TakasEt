import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NativeHttpClientService } from 'src/app/services/native-http-client.service';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private readonly baseUrl = "https://localhost:7166/api"

  constructor(
    private httpClient : NativeHttpClientService
  ) {}

  login(email : string,password : string): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>(`${this.baseUrl}/login/loginbyemail`,{email : email,password : password});
  }

  loginByRefreshToken(userId : string,token : string): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>(
      `${this.baseUrl}/login/LoginByRefreshToken`,
      {userId : userId, token : token}
    );
  }

}
