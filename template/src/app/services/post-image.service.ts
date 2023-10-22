import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { AppFileService } from './app-file.service';
import { UrlHelper } from '../helpers/url-helper';
import { Page } from '../states/app-states';

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

  getFirstImagesOfPosts(page : Page) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(
        UrlHelper.createPaginationUrl("post-image/get-first-images-of-posts",page)
      )
    )
  }

  getFirstImagesOfPostsByUserId(userId : string,page : Page) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(
        UrlHelper.createPaginationUrl(`post-image/get-first-images-of-posts-by-user-id/${userId}`,page))
    )
  }

  getFirstImagesOfPostsByUserName(userName : string,page : Page) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(
        UrlHelper.createPaginationUrl(
          `post-image/get-first-images-of-posts-by-user-name/${userName}`,page
          )
      )
    )
  }

  getFirstImageOfPostsExceptReuqesters(postId : string,page : Page) : Observable<string[]>{
    return this.appFileService.createUrlsFromBlob(
      this.appHttpClient.getBlob(
        UrlHelper.createPaginationUrl(
          `post-image/get-first-images-of-posts-except-reuqesters/${postId}`,page)
        )
    );
  }
}
