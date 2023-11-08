import { LoginResponse } from "src/app/models/responses/login-response";

export interface AppLoginState{
    loginResponse : LoginResponse | undefined;
    profileImage : string | undefined;
    isLogin : boolean;
}