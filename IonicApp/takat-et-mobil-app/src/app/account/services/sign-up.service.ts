import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { SignUpByEmail } from "../models/requests/sign-up-by-email";
import { NoContentResponse } from "src/app/models/responses/no-content-response";

@Injectable({
  providedIn : "root"
})
export class SignUpService{

  private readonly baseUrl = "https://localhost:7166/api/signup"

  constructor(private readonly httpClient : NativeHttpClientService) {}

  signUpByEmail(request : SignUpByEmail){
    return this.httpClient.post<NoContentResponse>(`${this.baseUrl}/signupbyemail`,request);
  }

}
