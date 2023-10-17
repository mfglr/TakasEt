import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { CommentResponse } from '../models/responses/comment-response';
import { AddComment } from '../models/requests/add-comment';

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
  getCommnetsByPostId(postId : string) : Observable<CommentResponse[]>{
    return this.appHttpClient.get<CommentResponse[]>(`comment/get-comments-by-post-id/${postId}`);
  }
  getCommnetWithChildren(id : string) : Observable<CommentResponse>{
    return this.appHttpClient.get<CommentResponse>(`comment/get-comment-with-children/${id}`);
  }
}
