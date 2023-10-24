import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class PostPostRequestingService {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  addRequestings(requestedId : string, requesterIds : string[]){
    return this.appHttpClient.post(
      "requesting/add-requestings",
      {requestedId : requestedId , requesterIds : requesterIds}
    );
  }

}
