import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserFollowingService{

  constructor(
    private httpClient : NativeHttpClientService
  ) { }

  follow(userId : number) : Observable<NoContentResponse>{
    return this.httpClient.post<NoContentResponse>("following/follow-user",{followedId : userId});
  }

  unfollow(userId : number) : Observable<NoContentResponse>{
    return this.httpClient.delete(`following/unfollow-user/${userId}`);
  }

  removeFollower(userId : number) : Observable<NoContentResponse>{
    return this.httpClient.delete(`following/remove-follower/${userId}`);
  }




}
