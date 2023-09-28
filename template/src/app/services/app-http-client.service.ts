import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserState } from '../states/user/state';
import { Store } from '@ngrx/store';
import { getLoginResponse} from '../states/user/selector';
import { Observable, map, mergeMap, take } from 'rxjs';
import { AppResponse } from '../models/responses/app-response';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class AppHttpClientService {

  constructor(
    private httpClient: HttpClient,
    private store : Store<UserState>) {

  }

  private baseUrl : string = 'http://localhost:7188/api'
  private getLoginResponse$ = this.store.select(getLoginResponse);

  public get<T>(url : string) : Observable<T>{
    return this.getLoginResponse$.pipe(
      take(1),
      mergeMap(
        (loginResponse) => {
          if(loginResponse) return this.httpClient.get<AppResponse<T>>(
            `${this.baseUrl}/${url}`,
            { headers : new HttpHeaders({"Authorization" : `Bearer ${loginResponse.accessToken}`}) }
          )
          return this.httpClient.get<AppResponse<T>>(`${this.baseUrl}/${url}`);
        }
      ),
      map(appResponse => appResponse.data)
    )
  }

  public post<T>(url : string,request : any) : Observable<T>{
    return this.getLoginResponse$.pipe(
      take(1),
      mergeMap( loginResponse => {
        if(loginResponse) return this.httpClient.post<AppResponse<T>>(
          `${this.baseUrl}/${url}`,
          request,
          { headers : new HttpHeaders({"Authorization" : `Bearer ${loginResponse.accessToken}`}) }
        )
        return this.httpClient.post<AppResponse<T>>( `${this.baseUrl}/${url}`, request )
      }),
      map(appResponse => appResponse?.data)
    )
  }

  public put(url : string,request : any) : Observable<NoContentResponse>{
    return this.getLoginResponse$.pipe(
      take(1),
      mergeMap(loginResponse => {
        if(loginResponse) return this.httpClient.post<AppResponse<NoContentResponse>>(
          `${this.baseUrl}/${url}`,
          request,
          { headers : new HttpHeaders({"Authorization" : `Bearer ${loginResponse.accessToken}`}) }
        )
        return this.httpClient.put<AppResponse<NoContentResponse>>( `${this.baseUrl}/${url}`, request )
      }),
      map(appResponse => appResponse?.data)
    )
  }

  public delete(url : string) : Observable<NoContentResponse>{
    return this.getLoginResponse$.pipe(
      take(1),
      mergeMap(
        (loginResponse) => {
          if(loginResponse) return this.httpClient.get<AppResponse<NoContentResponse>>(
            `${this.baseUrl}/${url}`,
            { headers : new HttpHeaders({"Authorization" : `Bearer ${loginResponse.accessToken}`}) }
          )
          return this.httpClient.get<AppResponse<NoContentResponse>>(`${this.baseUrl}/${url}`);
        }
      ),
      map(appResponse => appResponse.data)
    )
  }

}
