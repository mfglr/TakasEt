import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, first, from, map, mergeMap } from 'rxjs';
import { AppResponse } from '../models/responses/app-response';
import { CapacitorHttp } from '@capacitor/core';
import { NoContentResponse } from '../models/responses/no-content-response';
import { AppState } from '../state/reducer';
import { selectAccessToken } from '../state/selector';

@Injectable({
  providedIn: 'root'
})
export class NativeHttpClientService {

  private baseUrl : string = 'https://localhost:7160/api'

  constructor(
    private appStore : Store<AppState>
  ) { }

  private getHttpHeaders$ : Observable<any> = this.appStore.select(selectAccessToken).pipe(
    first(),
    map(accessToken => {
      if(accessToken) return { "Authorization" : `Bearer ${accessToken}`, 'Content-Type': 'application/json' }
      return {'Content-Type' : 'application/json'};
    })
  );

  get<T>(url : string) : Observable<T>{
    return this.getHttpHeaders$.pipe(
      mergeMap(headers => from(CapacitorHttp.get({url : `${this.baseUrl}/${url}`,headers : headers}))),
      map(response => (response.data as AppResponse<T>).data)
    )
  }

  getBlob(url : string) : Observable<string>{
    return this.getHttpHeaders$.pipe(
      mergeMap(
        (headers) => from(
          CapacitorHttp.get({ url : `${this.baseUrl}/${url}`, headers : headers, responseType : "blob" })
        )
      ),
      map(x => `data:image/jpeg;base64,${x.data}`)
    )
  }

  post<T>(url: string, request: any): Observable<T> {
    return this.getHttpHeaders$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.post({
            url : `${this.baseUrl}/${url}`,
            headers : headers,
            data : request
          })
        )
      ),
      map(response => (response.data as AppResponse<T>).data)
    )
  }

  put(url: string, request: any): Observable<NoContentResponse> {
    return this.getHttpHeaders$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.put({
            url : `${this.baseUrl}/${url}`,
            headers : headers,
            data : request
          })
        )
      ),
      map(response => (response.data as AppResponse<NoContentResponse>).data)
    )
  }

  delete(url: string): Observable<NoContentResponse> {
    return this.getHttpHeaders$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.delete({
            url : `${this.baseUrl}/${url}`,
            headers : headers,
          })
        )
      ),
      map(response => (response.data as AppResponse<NoContentResponse>).data)
    )
  }



}
