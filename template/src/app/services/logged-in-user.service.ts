import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggedInUserService {
  private _email? : string;
  
  public set email(email:string){
    this._email = email;
  }
  
  public get email() : string | undefined{
    return this._email;
  }
}
