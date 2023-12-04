import { Injectable } from '@angular/core';
import { Observable, from, map, mergeMap, toArray } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { UrlHelper } from '../helpers/url-helper';
import { NativeHttpClientService } from './native-http-client.service';
import { Page } from '../states/app-states';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private nativeHttpClientService: NativeHttpClientService,
  ) { }

  addPost(formData : FormData) : Observable<NoContentResponse>{
    return this.nativeHttpClientService.post<NoContentResponse>("post/add-post",formData);
  }

  getHomePosts(page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-home-posts?${UrlHelper.createPaginationQueryString(page)}`
    )
  }
  
  getPostsByUserId(userId : string) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`);
  }

  getPostsExceptRequesters(postId : number) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(`post/get-posts-except-requesters/${postId}`);
  }
}
