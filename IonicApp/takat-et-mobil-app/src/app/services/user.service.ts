import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserResponse } from '../models/responses/user-response';
import { AppHttpClientService } from './app-http-client.service';
import { NoContentResponse } from '../models/responses/no-content-response';
import { UrlHelper } from '../helpers/url-helper';
import { Page } from '../models/requests/page';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private appHttpClient: AppHttpClientService,
    ) {
  }

  getUserByUserName(userName : string) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`user/get-user-by-username/${userName}`);
  }

  getUser(userId : number) : Observable<UserResponse>{
    return this.appHttpClient.get<UserResponse>(`user/get-user/${userId}`);
  }

  getUsersWhoLikedPost(postId : number,page : Page) : Observable<UserResponse[]>{
    return this.appHttpClient.get<UserResponse[]>(
      `user/get-users-who-liked-post/${postId}?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

  addProfileImage(formData:FormData) : Observable<NoContentResponse> {
    return this.appHttpClient.post<NoContentResponse>('user/add-profile-image',formData);
  }
}
