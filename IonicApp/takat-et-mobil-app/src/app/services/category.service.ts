import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResponse } from '../models/responses/CategoryReponse';
import { NativeHttpClientService } from './native-http-client.service';
import { UrlHelper } from '../helpers/url-helper';
import { Page } from '../states/app-entity-state/app-entity-state';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient : NativeHttpClientService) {}

  filerCategories(key : string) : Observable<CategoryResponse[]>{
    return this.httpClient.get<CategoryResponse[]>(`category/filter-categories/${key}`);
  }

  getCategories(page : Page) : Observable<CategoryResponse[]>{
    return this.httpClient.get<CategoryResponse[]>(
      `category/get-categories?${UrlHelper.createPaginationQueryString(page)}`
    )
  }
}
