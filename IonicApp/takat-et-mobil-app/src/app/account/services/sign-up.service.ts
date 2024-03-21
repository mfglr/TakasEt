import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { SignUpByEmail } from "../models/requests/sign-up-by-email";
import { LoginResponse } from "../models/login-response";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn : "root"
})
export class SignUpService{

  private readonly baseUrl = `${environment.authService}/signup`;

  constructor(private readonly httpClient : NativeHttpClientService) {}

  signUpByEmail(request : SignUpByEmail){
    return this.httpClient.post<LoginResponse>(
      `${this.baseUrl}/signupbyemail`,
      {
        ...request,
        timeZone : Intl.DateTimeFormat().resolvedOptions().timeZone,
        offset : new Date().getTimezoneOffset()
      }
    );
  }

}
