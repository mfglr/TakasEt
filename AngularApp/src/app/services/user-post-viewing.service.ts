import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { NoContentResponse } from '../models/responses/no-content-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserPostViewingService {

  constructor(
    private appHttpClient : AppHttpClientService
    ) { }

  viewPost(postId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("user-user-viewing/view-post",{postId : postId});
  }
}
