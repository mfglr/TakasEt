import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { Likeable } from '../interfaces/likeable';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private appHttpClient: AppHttpClientService
  ) { }

  addPost(formData : FormData) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("post/add-post",formData);
  }

  getById(postId : string) : Observable<PostResponse>{
    return this.appHttpClient.get<PostResponse>(`post/get-by-id/${postId}`);
  }

  getPostsByUserId(userId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`);
  }

  like(postId : string) : Observable<NoContentResponse>{
    return this.appHttpClient.post("post/like-post",{"postId" : postId});
  }

  unlike(postId :string) : Observable<NoContentResponse>{
    return this.appHttpClient.delete(`post/unlike-post/${postId}`);
  }
}
