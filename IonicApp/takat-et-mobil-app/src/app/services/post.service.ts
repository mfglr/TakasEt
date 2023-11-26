import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable, from, map, mergeMap, toArray } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { UrlHelper } from '../helpers/url-helper';
import { AppFileService } from './app-file.service';
import { Page } from '../models/requests/page';
import { PostFilterRequest } from '../models/requests/post-filter-request';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private appHttpClient: AppHttpClientService,
    private appFileService : AppFileService
  ) { }

  addPost(formData : FormData) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("post/add-post",formData);
  }

  getPost(postId : string) : Observable<PostResponse>{
    return this.appHttpClient.get<PostResponse>(`post/get-post/${postId}`);
  }

  getPosts(page : Page) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(
      `post/get-posts?${UrlHelper.createPaginationQueryString(page)}`
    );
  }

  getPostsByFollowedUsers(page : Page) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(
      `post/get-posts-by-followed-users?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getPostsByFilter(request : PostFilterRequest){
    return this.appHttpClient.get<PostResponse[]>(
      `post/get-posts-by-filter?${UrlHelper.createPostFilteringQueryString(request)}`
    )
  }
  
  getPostsByUserId(userId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`);
  }


  getPostsByUserName(userName : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-name/${userName}`);
  }

  getPostsExceptRequesters(postId : number) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-except-requesters/${postId}`);
  }
}
