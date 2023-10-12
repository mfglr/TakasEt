import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';

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

  getPost(postId : string) : Observable<PostResponse>{
    return this.appHttpClient.get<PostResponse>(`post/get-post/${postId}`);
  }

  getPostsByUserId(userId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`);
  }

  getPostsByUserName(userName : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-name/${userName}`);
  }

  getPostsExceptRequesters(postId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-except-requesters/${postId}`);
  }
}
