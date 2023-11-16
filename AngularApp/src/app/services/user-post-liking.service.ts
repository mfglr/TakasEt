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

  like(postId : number) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("user-post-liking/like-post",{postId : postId});
  }

  unlike(postId : number) : Observable<NoContentResponse>{
    return this.appHttpClient.delete(`user-post-liking/unlike-post/${postId}`);
  }

  isLiked(postId: number): Observable<boolean> {
    return this.appHttpClient.get<boolean>(`user-post-liking/is-liked/${postId}`)
  }
}
