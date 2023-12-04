import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserPostLikingService {

  constructor(
    private nativeHttpClientService: NativeHttpClientService,
  ) { }

  like(postId : number) : Observable<NoContentResponse>{
    return this.nativeHttpClientService.post<NoContentResponse>("user-post-liking/like-post",{postId : postId});
  }

  unlike(postId : number) : Observable<NoContentResponse>{
    return this.nativeHttpClientService.delete(`user-post-liking/unlike-post/${postId}`);
  }

  isLiked(postId: number): Observable<boolean> {
    return this.nativeHttpClientService.get<boolean>(`user-post-liking/is-liked/${postId}`)
  }
}
