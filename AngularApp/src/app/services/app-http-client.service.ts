import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map, mergeMap, take } from 'rxjs';
import { AppResponse } from '../models/responses/app-response';
import { NoContentResponse } from '../models/responses/no-content-response';
import { AppLoginState } from '../states/login_state/state';
import { selectAccessToken } from '../states/login_state/selectors';

@Injectable({
  providedIn: 'root'
})
export class AppHttpClientService {

  constructor(
    private httpClient: HttpClient,
    private store : Store<AppLoginState>
  ) { }

  private baseUrl : string = 'http://localhost:5027/api'
  private getHttpHeaders$ = this.store.select(selectAccessToken).pipe(
    take(1),
    map(accessToken => {
      if(accessToken) return new HttpHeaders( {"Authorization" : `Bearer ${accessToken}`} )
      return undefined;
    })
  );

  get<T>(url : string) : Observable<T>{
    return this.getHttpHeaders$.pipe(
      mergeMap( (headers) => this.httpClient.get<AppResponse<T>>(`${this.baseUrl}/${url}`,{headers : headers}) ),
      map(appResponse => appResponse.data)
    )
  }

  getBlob(url : string) : Observable<Blob>{
    return this.getHttpHeaders$.pipe(
      mergeMap( (headers) => this.httpClient.get(`${this.baseUrl}/${url}`,{headers : headers,responseType : "blob"}) ),
    )
  }


  post<T>(url : string,request : any) : Observable<T>{
    return this.getHttpHeaders$.pipe(
      mergeMap( headers => this.httpClient.post<AppResponse<T>>( `${this.baseUrl}/${url}`, request, {headers : headers} ) ),
      map(appResponse => appResponse?.data)
    )
  }

  put(url : string,request : any) : Observable<NoContentResponse>{
    return this.getHttpHeaders$.pipe(
      mergeMap(headers => this.httpClient.post<AppResponse<NoContentResponse>>( `${this.baseUrl}/${url}`,request,{headers : headers}) ),
      map(appResponse => appResponse?.data)
    )
  }

  delete(url : string) : Observable<NoContentResponse>{
    return this.getHttpHeaders$.pipe(
      mergeMap( (headers) => this.httpClient.delete<AppResponse<NoContentResponse>>( `${this.baseUrl}/${url}`,{headers : headers}) ),
      map(appResponse => appResponse.data)
    )
  }
}
