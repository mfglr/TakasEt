import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { AppFileService } from './app-file.service';

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

  getById(postId : string) : Observable<PostResponse>{
    return this.appHttpClient.get<PostResponse>(`post/get-by-id/${postId}`);
  }

  getPostImagesByPostId(postId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(this.appHttpClient.getBlob(`post/get-post-images-by-post-id/${postId}`))
  }
}
