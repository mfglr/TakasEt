import { Injectable } from "@angular/core";
import { GetConversations } from "../models/request/get-conversations";
import { Observable } from "rxjs";
import { AppResponse } from "src/app/models/responses/app-response";
import { ConversationResponse } from "../models/responses/conversation-response";
import { NativeHttpClientService } from "src/app/services/native-http-client.service";

@Injectable({ "providedIn" : "root"})
export class ConversationService{

  private readonly baseUrl : string = "https://localhost:7200/api/conversation";

  constructor(private readonly httpClient : NativeHttpClientService) {}

  getConversations(request : GetConversations) : Observable<AppResponse<ConversationResponse[]>>{
    return this.httpClient.get<ConversationResponse[]>(`${this.baseUrl}/GetConversations`)
  }

}
