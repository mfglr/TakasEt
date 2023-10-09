import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { AppFileService } from './app-file.service';

@Injectable({
  providedIn: 'root'
})
export class PostImageService {

  constructor(
    private appHttpClient: AppHttpClientService,
    private appFileService : AppFileService
    ) { }

  getPostImagesByPostId(postId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(this.appHttpClient.getBlob(`post-image/get-post-images-by-post-id/${postId}`))
  }

  getFirsImagesOfPostByUserId(userId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(this.appHttpClient.getBlob(`post-image/get-first-image-of-posts-by-user-id/${userId}`))
  }
}
