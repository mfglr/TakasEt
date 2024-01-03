import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserResponse } from '../models/responses/user-response';
import { NoContentResponse } from '../models/responses/no-content-response';
import { UrlHelper } from '../helpers/url-helper';
import { NativeHttpClientService } from './native-http-client.service';
import { Page } from '../states/app-entity-state';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: NativeHttpClientService,
  ) {
  }

  getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.httpClient.get<UserResponse>(`user/get-user-by-username/${userName}`);
  }

  getUser(userId : number) : Observable<UserResponse>{
    return this.httpClient.get<UserResponse>(`user/get-user/${userId}`);
  }

  getUsersWhoLikedPost(postId : number,page : Page) : Observable<UserResponse[]>{
    return this.httpClient.get<UserResponse[]>(
      `user/get-users-who-liked-post/${postId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getFollowers(userId : number,page : Page) : Observable<UserResponse[]>{
    return this.httpClient.get<UserResponse[]>(
      `user/get-followers/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  getFolloweds(userId : number,page : Page) : Observable<UserResponse[]>{
    return this.httpClient.get<UserResponse[]>(
      `user/get-followeds/${userId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  addProfileImage(formData:FormData) : Observable<NoContentResponse> {
    return this.httpClient.post<NoContentResponse>('user/add-profile-image',formData);
  }

  getSearchPageUsers(key : string | undefined, page : Page) : Observable<UserResponse[]>{
    let url;
    if(key) url = `user/get-search-page-users?key=${key}&${UrlHelper.createPaginationQueryString(page)}`;
    else url = `user/get-search-page-users?${UrlHelper.createPaginationQueryString(page)}`;
    return this.httpClient.get<UserResponse[]>(url);
  }
}
