import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class PostPostRequestingService {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  addSwapRequests(requestedId : string, requesterIds : string[]){
    return this.appHttpClient.post(
      "post-post-requesting/add-swap-requests",
      {requestedId : requestedId , requesterIds : requesterIds}
    );
  }

}
