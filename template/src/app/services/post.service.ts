import { Injectable } from '@angular/core';
import { AppHttpClientService } from './app-http-client.service';
import { Observable } from 'rxjs';
import { NoContentResponse } from '../models/responses/no-content-response';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private appHttpClient: AppHttpClientService) { }

  addPost(formData : FormData) : Observable<NoContentResponse>{
    return this.appHttpClient.post<NoContentResponse>("post/add-post",formData);
  }
}
