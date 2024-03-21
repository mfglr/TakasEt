import { Injectable } from "@angular/core";
import { GetConversations } from "../models/request/get-conversations";
import { Observable } from "rxjs";
import { AppResponse } from "src/app/models/responses/app-response";
import { ConversationResponse } from "../models/responses/conversation-response";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { mapDateTimesOfConversations } from "src/app/customOperators/mapping-datetime-operators";
import { UrlHelper } from "src/app/helpers/url-helper";
import { environment } from "src/environments/environment";

@Injectable({ "providedIn" : "root"})
export class ConversationService{

  private readonly baseUrl = `${environment.conversationService}/conversation`;

  constructor(private readonly httpClient : NativeHttpClientService) {}

  getConversations(request : GetConversations) : Observable<AppResponse<ConversationResponse[]>>{
    return this.httpClient.get<ConversationResponse[]>(
      `${this.baseUrl}/GetConversations?${UrlHelper.createPaginationQueryString(request)}`
    ).pipe(mapDateTimesOfConversations())
  }

}
