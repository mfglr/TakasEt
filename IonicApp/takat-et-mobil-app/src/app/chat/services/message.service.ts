import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { Observable } from "rxjs";
import { AppResponse, BaseAppresponse } from "src/app/models/responses/app-response";
import { UrlHelper } from "src/app/helpers/url-helper";
import { GetMessages } from "../models/request/get-messages";
import { MessageResponse } from "src/app/chat/models/responses/message-response";
import { mapDateTimesOfMessages } from "src/app/customOperators/mapping-datetime-operators";
import { GetNewMessages } from "../models/request/get-new-messages";
import { MarkNewMessagesAsReceived } from "../models/request/mark-messages-as-received";
import { environment } from "src/environments/environment";

@Injectable({ providedIn : 'root' })
export class MessageService{

  private readonly baseUrl = `${environment.conversationService}/message`;

  constructor(
    private readonly httpClient : NativeHttpClientService
  ) {}

  getMessages(request : GetMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/getmessages/${request.userId}?${UrlHelper.createPaginationQueryString(request)}`
    ).pipe(mapDateTimesOfMessages())
  }

  getNewMessages(request : GetNewMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(`${this.baseUrl}/getNewMessages`)
      .pipe(mapDateTimesOfMessages())
  }

  markNewMessagesAsReceived(request : MarkNewMessagesAsReceived) : Observable<BaseAppresponse>{
    return this.httpClient.put(`${this.baseUrl}/markNewMessagesAsReceived`,request)
  }

}
