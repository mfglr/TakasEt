import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { GetConversations } from "../pages/chat-home/models/requests/get-conversations";
import { Observable } from "rxjs";
import { AppResponse } from "src/app/models/responses/app-response";
import { UrlHelper } from "src/app/helpers/url-helper";
import { GetConversationsThatHaveNewMessages } from "../pages/chat-home/models/requests/get-conversations-that-have-new-messages";
import { ConversationResponse } from "../pages/chat-home/models/responses/conversation-response";
import { GetMessages } from "../models/request/get-messages";
import { MessageResponse } from "src/app/models/responses/message-response";

@Injectable({ providedIn : 'root' })
export class ConversationService{


  private readonly baseUrl : string = "https://localhost:7200/api/conversation";

  constructor(
    private readonly httpClient : NativeHttpClientService
  ) {}

  getConversations(request : GetConversations) : Observable<AppResponse<ConversationResponse[]>>{
    return this.httpClient.get<ConversationResponse[]>(
      `${this.baseUrl}/getconversations?${UrlHelper.createPaginationQueryString(request)}`
    )
  }

  getMessages(request : GetMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/getmessages/${request.userId}?${UrlHelper.createPaginationQueryString(request)}`
    )
  }

}
