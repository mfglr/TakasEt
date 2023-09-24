import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccessTokenProviderService {

  private _httpHeaders : HttpHeaders = new HttpHeaders();
  
  public get httpHeaders() : HttpHeaders{
    return this._httpHeaders;
  }

  public setAccessToken(token? : string) : void{
    this._httpHeaders = new HttpHeaders({"Authorization" : `Bearer ${token}`}) 
  }
  
}
