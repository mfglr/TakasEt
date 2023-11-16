import { Injectable } from '@angular/core';
import { Observable, first, from, map, mergeMap, toArray } from 'rxjs';
import { AppFileReaderService } from './app-file-reader.service';
import { BlobTypesService } from './blob-types.service';
import { AppHttpClientService } from './app-http-client.service';
import { PostResponse } from '../models/responses/post-response';

@Injectable({
  providedIn: 'root'
})
export class AppFileService {
  constructor(
    private appFileReader : AppFileReaderService,
    private blobTypes : BlobTypesService,
    private appHttpClient : AppHttpClientService
  ){}

  createUrlsFromBlob(source : Observable<Blob>) : Observable<string[]>{
    return source.pipe(
      mergeMap(blob => from(blob.arrayBuffer())),
      map( arrayBuffer => this.appFileReader.getFiles(new Uint8Array(arrayBuffer)) ),
      mergeMap(
        files => from(files).pipe(
          map(
            file => URL.createObjectURL(
              new Blob([file.file],{type : this.blobTypes.getBlobTypeByExtention(file.extention)})
            )
          ),
          toArray()
        )
      )
    )
  }

  createPostsFromBlob(source : Observable<Blob>) : Observable<PostResponse[]>{
    return source.pipe(
      mergeMap(blob => from(blob.arrayBuffer())),
      map(arrayBuffer => this.appFileReader.getPosts(new Uint8Array(arrayBuffer))),
      mergeMap(
        posts => from(posts).pipe(
          map(
            post => {
              post.post.firstImage = URL.createObjectURL(
                new Blob([post.file],{type : this.blobTypes.getBlobTypeByExtention(post.extention)})
              )
              return post.post;
            }
          ),
          toArray()
        )
      )
    )
  }

  getAppFile(containerName : string,blobName : string) : Observable<string>{
    return this.createUrlsFromBlob(
      this.appHttpClient.getBlob(`app-file/get-app-file/${containerName}/${blobName}`)
    ).pipe(
      mergeMap( (urls) => from(urls) ),
      first()
    );
  }
}
