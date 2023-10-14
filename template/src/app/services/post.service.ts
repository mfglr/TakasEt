import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable, from, map, mergeMap, toArray } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';
import { PostResponse } from '../models/responses/post-response';
import { PostImageService } from './post-image.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private appHttpClient: AppHttpClientService,
    private postImageService : PostImageService
  ) { }

  addPost(formData : FormData) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("post/add-post",formData);
  }

  getPost(postId : string) : Observable<PostResponse>{
    return this.appHttpClient.get<PostResponse>(`post/get-post/${postId}`);
  }

  getPosts() : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts`);
  }

  getPostsWithFirstImages() : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts`).pipe(
      mergeMap(
        posts => this.postImageService.getFirstImagesOfPosts().pipe(
          mergeMap( images => from(images) ),
          map(
            (image,index) => {
              posts[index].images = [image];
              return posts[index];
            }
          ),
          toArray()
        ),
      )
    )
  }

  getPostsByUserId(userId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`);
  }

  getPostsWithFirstImagesByUserId(userId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-id/${userId}`).pipe(
      mergeMap(
        posts => this.postImageService.getFirstImagesOfPostsByUserId(userId).pipe(
          mergeMap( images => from(images) ),
          map(
            (image,index) => {
              posts[index].images = [image];
              return posts[index];
            }
          ),
          toArray()
        ),
      )
    )
  }
  getPostsByUserName(userName : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-by-user-name/${userName}`);
  }

  getPostsExceptRequesters(postId : string) : Observable<PostResponse[]>{
    return this.appHttpClient.get<PostResponse[]>(`post/get-posts-except-requesters/${postId}`);
  }
}
