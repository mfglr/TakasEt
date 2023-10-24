import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { Followable } from '../interfaces/followable';

@Injectable({
  providedIn: 'root'
})
export class UserFollowingService implements Followable {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  follow(followedId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("following/follow-user",{followedId : followedId});
  }

  unfollow(followedId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.delete(`following/unfollow-user/${followedId}`);
  }

  isFollowed(userId : string) : Observable<boolean>{
    return this.appHttpClient.get<boolean>(`following/is-followed/${userId}`)
  }
}
