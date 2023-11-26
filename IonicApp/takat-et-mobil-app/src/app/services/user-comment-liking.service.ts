import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Likeable } from '../interfaces/likeable';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class UserCommentLikingService implements Likeable {
  constructor(
    private appHttpClient : AppHttpClientService
  ) { }
  like(commentId : number) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("user-comment-liking/like-comment",{commentId : commentId});
  }
  unlike(commentId : number) : Observable<NoContentResponse>{
    return this.appHttpClient.delete(`user-comment-liking/unlike-comment/${commentId}`);
  }
  isLiked(commentId: number): Observable<boolean> {
    return this.appHttpClient.get<boolean>(`user-comment-liking/is-comment-liked/${commentId}`)
  }
}
