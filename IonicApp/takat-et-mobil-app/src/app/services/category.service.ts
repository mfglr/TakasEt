import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResponse } from '../models/responses/CategoryReponse';
import { NativeHttpClientService } from './native-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient : NativeHttpClientService) {}

  public filerCategories(key : string) : Observable<CategoryResponse[]>{
    return this.httpClient.get<CategoryResponse[]>(`category/filter-categories/${key}`);
  }

}
