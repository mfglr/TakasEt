import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserCommentLikingService {
  constructor(
    private httpClient : NativeHttpClientService
  ) { }
  like(commentId : number) : Observable<NoContentResponse>{
    return this.httpClient.post<NoContentResponse>("user-comment-liking/like-comment",{commentId : commentId});
  }
  unlike(commentId : number) : Observable<NoContentResponse>{
    return this.httpClient.delete(`user-comment-liking/unlike-comment/${commentId}`);
  }
  isLiked(commentId: number): Observable<boolean> {
    return this.httpClient.get<boolean>(`user-comment-liking/is-comment-liked/${commentId}`)
  }
}
