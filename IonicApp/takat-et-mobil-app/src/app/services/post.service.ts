import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { UrlHelper } from '../helpers/url-helper';
import { NativeHttpClientService } from './native-http-client.service';
import { Page } from '../states/app-entity-state';

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

  getSearchPosts(page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-search-posts?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getPostsByUserId(userId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-posts-by-user-id/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    );
  }

  getExplorePagePosts(tags : string[], categoryId : number,page : Page) : Observable<PostResponse[]>{
    return this.nativeHttpClientService.get<PostResponse[]>(
      `post/get-explore-page-posts?categoryId=${categoryId}&tags=${tags.join(",")}&${UrlHelper.createPaginationQueryString(page)}`
    )
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

}
