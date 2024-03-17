import { Injectable } from "@angular/core";
import { GetConversations } from "../models/request/get-conversations";
import { Observable, filter } from "rxjs";
import { AppResponse } from "src/app/models/responses/app-response";
import { ConversationResponse } from "../models/responses/conversation-response";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { mapDateTimesOfConversations } from "src/app/customOperators/mapping-datetime-operators";
import { UrlHelper } from "src/app/helpers/url-helper";

@Injectable({ "providedIn" : "root"})
export class ConversationService{

  private readonly baseUrl : string = "https://localhost:7200/api/conversation";

  constructor(private readonly httpClient : NativeHttpClientService) {}

  getConversations(request : GetConversations) : Observable<AppResponse<ConversationResponse[]>>{
    return this.httpClient.get<ConversationResponse[]>(
      `${this.baseUrl}/GetConversations?${UrlHelper.createPaginationQueryString(request)}`
    ).pipe(
      mapDateTimesOfConversations(),
    )
  }

}
