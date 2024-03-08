import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, first, from, map, mergeMap } from 'rxjs';
import { AppResponse, BaseAppresponse } from '../models/responses/app-response';
import { CapacitorHttp } from '@capacitor/core';
import { LoginState } from '../account/state/reducer';
import { selectAccessToken } from '../account/state/selectors';

@Injectable({
  providedIn: 'root'
})
export class NativeHttpClientService {

  constructor( private loginStore : Store<LoginState> ) { }

  private getHttpHeadersJson$ : Observable<any> = this.loginStore.select(selectAccessToken).pipe(
    first(),
    map(accessToken => {
      if(accessToken) return { "Authorization" : `Bearer ${accessToken}`, 'Content-Type': 'application/json' }
      return {'Content-Type' : 'application/json'};
    })
  );


  private getHttpHeadersFormData$ : Observable<any> = this.loginStore.select(selectAccessToken).pipe(
    first(),
    map(accessToken => {
      if(accessToken) return { "Authorization" : `Bearer ${accessToken}`, 'Content-Type': 'application/json' }
      return {'Content-Type' : 'multipart/form-data'};
    })
  );


  get<T>(url : string) : Observable<AppResponse<T>>{
    return this.getHttpHeadersJson$.pipe(
      mergeMap(headers => from(CapacitorHttp.get({url : url,headers : headers}))),
      map(response => (response.data as AppResponse<T>))
    )
  }

  getBlob(url : string) : Observable<string>{
    return this.getHttpHeadersJson$.pipe(
      mergeMap( (headers) => from(CapacitorHttp.get({ url : url, headers : headers, responseType : "blob" }))),
      map(response=> `data:image/jpeg;base64,${response.data}`)
    )
  }

  postFormData(url : string, data : FormData) : Observable<BaseAppresponse>{
    return this.getHttpHeadersFormData$.pipe(
      mergeMap(
        (headers) => from(
          CapacitorHttp.post({url : url, headers : headers,data : data})
        )
      ),
      map(response => response.data as BaseAppresponse)
    )
  }

  post<T>(url: string, request: any): Observable<AppResponse<T>> {
    return this.getHttpHeadersJson$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.post({
            url : url,
            headers : headers,
            data : request
          })
        )
      ),
      map(response => response.data as AppResponse<T>)
    )
  }

  postNoContent(url: string, request: any): Observable<BaseAppresponse> {
    return this.getHttpHeadersJson$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.post({
            url : url,
            headers : headers,
            data : request
          })
        )
      ),
      map(response => response.data as BaseAppresponse)
    )
  }


  put(url: string, request?: any): Observable<BaseAppresponse> {
    return this.getHttpHeadersJson$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.put({
            url : url,
            headers : headers,
            data : request
          })
        )
      ),
      map(response => (response.data as BaseAppresponse))
    )
  }

  delete(url: string): Observable<BaseAppresponse> {
    return this.getHttpHeadersJson$.pipe(
      mergeMap(
        headers => from(
          CapacitorHttp.delete({
            url : url,
            headers : headers,
          })
        )
      ),
      map(response => (response.data as BaseAppresponse))
    )
  }

}
