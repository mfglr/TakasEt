import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppStringsService {
  public forgotPassword : string = "Forgot your password?";
  public login :string = "Login";
  public typePassword : string = "Type your password";
  public typeEmail : string = "Type your email"
}
