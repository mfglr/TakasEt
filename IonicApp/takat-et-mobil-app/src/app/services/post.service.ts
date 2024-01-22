import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { UrlHelper } from '../helpers/url-helper';
import { NativeHttpClientService } from './native-http-client.service';
import { Page } from '../states/app-entity-state/app-entity-state';
import { GetSearchPagePostsRequest } from '../models/requests/get-search-page-posts-request';

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

  getHomePagePosts(loggedInUserId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-home-page-posts?loggedInUserId=${loggedInUserId}&${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getSearchPagePosts(request : GetSearchPagePostsRequest) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-search-page-posts?${UrlHelper.createPaginationQueryString(request)}`
    );
  }

  getSearchPostListPagePosts(postId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-search-post-list-page-posts/${postId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getUserPosts(userId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-posts-by-user-id/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    );
  }

  getPostsExceptRequesters(postId : number) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(`post/get-posts-except-requesters/${postId}`);
  }

  getSwappedPosts(userId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-swapped-posts/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    );
  }

  getNotSwappedPosts(userId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-not-swapped-posts/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getPostsByCategoryId(categoryId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-posts-by-category-id/${categoryId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getFilterPagePosts(categoryIds : string | undefined, key : string | undefined,page : Page) : Observable<PostResponse[]>{
    let url = 'post/get-filter-page-posts?';
    if(categoryIds) url = `${url}categoryIds=${categoryIds}&`
    if(key) url = `${url}key=${key}&`
    return this.nativeHttpClientService.get<PostResponse[]>( `${url}${UrlHelper.createPaginationQueryString(page)}` )
  }

  getPostImage(id : number) : Observable<string>{
    return this.nativeHttpClientService.getBlob(`post/get-post-image/${id}`)
  }

}
