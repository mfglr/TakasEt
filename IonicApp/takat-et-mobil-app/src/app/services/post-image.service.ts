import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class PostImageService {

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  getPostImage(id : number) : Observable<string>{
    return this.httpClient.getBlob(`post-image/get-post-image/${id}`)
  }
}
