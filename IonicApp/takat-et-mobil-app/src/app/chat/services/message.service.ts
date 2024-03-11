import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { Observable } from "rxjs";
import { AppResponse, BaseAppresponse } from "src/app/models/responses/app-response";
import { UrlHelper } from "src/app/helpers/url-helper";
import { GetMessages } from "../models/request/get-messages";
import { MessageResponse } from "src/app/chat/models/responses/message-response";
import { MarkMessagesAsViewed } from "../models/request/mark-messages-as-viewed";
import { MarkMessagesAsReceived } from "../models/request/mark-messages-as-received";
import { GetNewMessages } from "../models/request/get-new-messages";

@Injectable({ providedIn : 'root' })
export class MessageService{


  private readonly baseUrl : string = "https://localhost:7200/api/message";

  constructor(
    private readonly httpClient : NativeHttpClientService
  ) {}

  getNewMessages(request : GetNewMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/GetNewMessages`
    )
  }

  getMessages(request : GetMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/getmessages/${request.userId}?${UrlHelper.createPaginationQueryString(request)}`
    )
  }

  markMessagesAsReceived(reqeust : MarkMessagesAsReceived) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/MarkMessagesAsReceived`,reqeust);
  }

  markMessagesAsViewed(reqeust : MarkMessagesAsViewed) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/MarkMessagesAsViewed`,reqeust);
  }

}
