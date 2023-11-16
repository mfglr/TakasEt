import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable, first, from, mergeMap } from 'rxjs';
import { AppFileService } from './app-file.service';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class ProfileImageService {

  constructor(
    private appHttpClient : AppHttpClientService,
    private appFileService : AppFileService
    ) { }

    getActiveProfileImage(userId : number) : Observable<string>{
      return this.appFileService.createUrlsFromBlob(
        this.appHttpClient.getBlob(`profile-image/get-active-profile-image/${userId}`)
      ).pipe(
        mergeMap( (urls) => from(urls) ),
        first()
      )
    }

    getActiveProfileImageByUserName(userName : string) : Observable<string>{
      return this.appFileService.createUrlsFromBlob(
        this.appHttpClient.getBlob(`profile-image/get-active-profile-image-by-user-name/${userName}`)
      ).pipe(
        mergeMap( (urls) => from(urls) ),
        first()
      )
    }


    addProfileImage(formData : FormData) : Observable<NoContentResponse>{
      return this.appHttpClient.post<NoContentResponse>("profile-image/add-profile-image",formData);
    }

}
