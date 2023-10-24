import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResponse } from '../models/responses/CategoryReponse';
import { AppHttpClientService } from './app-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private apphttpClient : AppHttpClientService) {}

  public filerCategories(key : string) : Observable<CategoryResponse[]>{
    return this.apphttpClient.get<CategoryResponse[]>(`category/filter-categories/${key}`);
  }

}
