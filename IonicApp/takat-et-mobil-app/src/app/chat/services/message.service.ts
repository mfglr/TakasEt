import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";
import { Observable } from "rxjs";
import { AppResponse } from "src/app/models/responses/app-response";
import { UrlHelper } from "src/app/helpers/url-helper";
import { GetMessages } from "../models/request/get-messages";
import { MessageResponse } from "src/app/chat/models/responses/message-response";
import { mapDateTimesOfMessages } from "src/app/customOperators/mapping-datetime-operators";

@Injectable({ providedIn : 'root' })
export class MessageService{


  private readonly baseUrl : string = "https://localhost:7200/api/message";

  constructor(
    private readonly httpClient : NativeHttpClientService
  ) {}

  getMessages(request : GetMessages) : Observable<AppResponse<MessageResponse[]>>{
    return this.httpClient.get<MessageResponse[]>(
      `${this.baseUrl}/getmessages/${request.userId}?${UrlHelper.createPaginationQueryString(request)}`
    ).pipe(mapDateTimesOfMessages())
  }

}
