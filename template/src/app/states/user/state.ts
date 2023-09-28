import { HttpHeaders } from "@angular/common/http";
import { LoginResponse } from "src/app/models/responses/login-response";

export interface UserState{
  loginResponse : LoginResponse | undefined
  isLogin : boolean;
}
