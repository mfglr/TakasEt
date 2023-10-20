import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { CommentResponse } from '../models/responses/comment-response';
import { AddComment } from '../models/requests/add-comment';
import { UrlHelper } from '../helpers/url-helper';
import { Page } from '../states/app-state';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(
    private appHttpClient : AppHttpClientService
  ) { }

  addComment(request : AddComment ) : Observable<CommentResponse>{
    return this.appHttpClient.post<CommentResponse>("comment/add-comment",request);
  }
  getCommnetsByPostId(postId : string,page : Page) : Observable<CommentResponse[]>{
    return this.appHttpClient.get<CommentResponse[]>(
      UrlHelper.createPaginationUrl(`comment/get-comments-by-post-id/${postId}`,page)
    );
  }
  getCommnetWithChildren(id : string) : Observable<CommentResponse>{
    return this.appHttpClient.get<CommentResponse>(`comment/get-comment-with-children/${id}`);
  }
}
