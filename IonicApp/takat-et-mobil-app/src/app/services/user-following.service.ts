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

  follow(followedId : string) : Observable<NoContentResponse>{
    return this.httpClient.post<NoContentResponse>("following/follow-user",{followedId : followedId});
  }

  unfollow(followedId : string) : Observable<NoContentResponse>{
    return this.httpClient.delete(`following/unfollow-user/${followedId}`);
  }

  isFollowed(userId : string) : Observable<boolean>{
    return this.httpClient.get<boolean>(`following/is-followed/${userId}`)
  }
}
