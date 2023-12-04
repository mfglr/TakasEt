import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AppFileService {
  constructor(
    private nativeHttpClientService : NativeHttpClientService
  ){}

  getAppFile(id : number) : Observable<string>{
    return this.nativeHttpClientService.getBlob(`app-file/get-app-file/${id}`)
  }

}
