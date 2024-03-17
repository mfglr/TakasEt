import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { AppResponse } from "../models/responses/app-response";
import { UserResponse } from "../models/responses/user-response";
import { Observable } from "rxjs";
import { UrlHelper } from "../helpers/url-helper";
import { GetUsersByIds } from "../models/requests/get-users-by-ids";
import { GetUserById } from "../models/requests/get-user-by-id";
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

  getUsersByIds(request : GetUsersByIds) : Observable<AppResponse<UserResponse[]>>{
    return this.httpClient.get<UserResponse[]>(`${this.baseUrl}/user/getusersbyids?ids=${request.ids.join(',')}`)
  }

  getUserById(request : GetUserById) : Observable<AppResponse<UserResponse>>{
    return this.httpClient.get<UserResponse>(`${this.baseUrl}/user/getuserbyid/${request.userId}`)
  }

}
