import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { GetConversationsWithNewMessages } from "../pages/chat-home/models/requests/get-conversations";
import { Observable } from "rxjs";
import { AppResponse, BaseAppresponse } from "src/app/models/responses/app-response";
import { UrlHelper } from "src/app/helpers/url-helper";
import { ConversationResponse } from "../models/responses/conversation-response";
import { GetMessages } from "../models/request/get-messages";
import { MessageResponse } from "src/app/chat/models/responses/message-response";
import { MarkMessagesAsViewed } from "../models/request/mark-messages-as-viewed";
import { MarkMessagesAsReceived } from "../models/request/mark-messages-as-received";
import { MarkAllNewMessagesAsReceived } from "../models/request/mark-all-new-messages-as-received";

@Injectable({ providedIn : 'root' })
export class ConversationService{


  private readonly baseUrl : string = "https://localhost:7200/api/conversation";

  constructor(
    private readonly httpClient : NativeHttpClientService
  ) {}

  getConversationsWithNewMessages(request : GetConversationsWithNewMessages) : Observable<AppResponse<ConversationResponse[]>>{
    return this.httpClient.get<ConversationResponse[]>(
      `${this.baseUrl}/GetConversationsWithNewMessages?timeStamp=${request.timeStamp.toJSON()}`
    )
  }

  getMessages(request : GetMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/getmessages/${request.receiverId}?${UrlHelper.createPaginationQueryString(request)}`
    )
  }

  markMessagesAsReceived(reqeust : MarkMessagesAsReceived) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/MarkMessagesAsReceived`,reqeust);
  }

  markMessagesAsViewed(reqeust : MarkMessagesAsViewed) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/MarkMessagesAsViewed`,reqeust);
  }

  markAllNewMessagesAsReceived(request : MarkAllNewMessagesAsReceived) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/MarkAllNewMessagesAsReceived`);
  }



}
