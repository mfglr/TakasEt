import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class FollowingService {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  followUser(followedId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("following/follow-user",{followedId : followedId});
  }

  unfollowUser(followedId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("following/unfollow-user",{followedId : followedId});
  }

  isFollowed(userId : string) : Observable<boolean>{
    return this.appHttpClient.get<boolean>(`following/is-followed/${userId}`)
  }
}
