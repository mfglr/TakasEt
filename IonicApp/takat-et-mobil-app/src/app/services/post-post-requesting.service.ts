import { Injectable } from '@angular/core';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class PostPostRequestingService {

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  addRequestings(requestedId : number, requesterIds : number[]){
    return this.httpClient.post(
      "requesting/add-requestings",
      {requestedId : requestedId , requesterIds : requesterIds}
    );
  }

}
