import { Injectable } from '@angular/core';
import { Likeable } from '../interfaces/likeable';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class UserPostLikingService implements Likeable {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  like(postId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("user-post-liking/like-post",{postId : postId});
  }

  unlike(postId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.delete(`user-post-liking/unlike-post/${postId}`);
  }

  IsLikedLoggedInUser(postId : string): Observable<boolean>{
    return this.appHttpClient.get<boolean>(`user-post-liking/is-liked-logged-in-user-the-post/${postId}`);
  }
}
