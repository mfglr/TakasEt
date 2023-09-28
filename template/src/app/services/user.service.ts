import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/responses/login-response';
import { UserResponse } from '../models/responses/user-response';
import { AppHttpClientService } from './app-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private appHttpClient: AppHttpClientService) {
  }

  public login(email : string,password : string): Observable<LoginResponse>{
    return this.appHttpClient.post<LoginResponse>("login",{email : email,password : password});
  }

  public getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`get-user-by-username/${userName}`);
  }

}
