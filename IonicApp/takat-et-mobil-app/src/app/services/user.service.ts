import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { AppResponse } from "../models/responses/app-response";
import { UserResponse } from "../models/responses/user-response";
import { Observable } from "rxjs";
import { UrlHelper } from "../helpers/url-helper";
import { Page } from "../state/app-entity-state/app-entity-state";

@Injectable({
  providedIn : "root"
})
export class UserService{

  private readonly baseUrl : string = "https://localhost:7267/api";

  constructor(private readonly httpClient : NativeHttpClientService) {}

  getFollowersOrFollowings(page : Page) : Observable<AppResponse<UserResponse[]>>{
    return this.httpClient.get<UserResponse[]>(
      `${this.baseUrl}/user/GetFollowersAndFollowings?${UrlHelper.createPaginationQueryString(page)}`
    )
  }

}
