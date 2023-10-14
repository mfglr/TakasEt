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

  getPostImages(postId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(`post-image/get-post-images/${postId}`)
    )
  }

  getFirstImagesOfPosts() : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(`post-image/get-first-images-of-posts`)
    )
  }

  getFirstImagesOfPostsByUserId(userId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(`post-image/get-first-images-of-posts-by-user-id/${userId}`)
    )
  }

  getFirstImagesOfPostsByUserName(userName : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(`post-image/get-first-images-of-posts-by-user-name/${userName}`)
    )
  }

  getFirstImageOfPostsExceptReuqesters(postId : string) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(`post-image/get-first-images-of-posts-except-reuqesters/${postId}`)
    );
  }
}
