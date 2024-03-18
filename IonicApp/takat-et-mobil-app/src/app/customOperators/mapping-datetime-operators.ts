import { Observable, map } from "rxjs";
import { MessageResponse } from "../chat/models/responses/message-response";
import { AppResponse } from "../models/responses/app-response";
import { ConversationResponse } from "../chat/models/responses/conversation-response";

export function mapDateTimesOfMessages(){
  return (source : Observable<AppResponse<MessageResponse[]>>) => source.pipe(
    map(respone => {
      if(!respone.isError)
        return {
          ...respone,
          data : respone.data!.map(
            (message) : MessageResponse => ({
              ...message,
              createdDate : new Date(message.createdDate),
              updatedDate : message.updatedDate ? new Date(message.updatedDate) : message.updatedDate,
              sendDate : new Date(message.sendDate),
              receivedDate : message.receivedDate ? new Date(message.receivedDate) : message.receivedDate,
              viewedDate : message.viewedDate ? new Date(message.viewedDate) : message.viewedDate,
            })
          )
        }
      return respone;
    })
  )
}

export function mapDateTimesOfConversations(){
  return (source : Observable<AppResponse<ConversationResponse[]>>) => source.pipe(
    map(response => {
      if(!response.isError){
        return {
          ...response,
          data : response.data!.map((c) : ConversationResponse => ({
            ...c,
            createdDate : new Date(c.createdDate),
            updatedDate : c.updatedDate ? new Date(c.updatedDate) : c.updatedDate,
            messages : c.messages.map((m) : MessageResponse => ({
              ...m,
              createdDate : new Date(m.createdDate),
              updatedDate : m.updatedDate ? new Date(m.updatedDate): m.updatedDate,
              sendDate : new Date(m.sendDate),
              receivedDate : m.receivedDate ? new Date(m.receivedDate) : m.receivedDate,
              viewedDate : m.viewedDate ? new Date(m.viewedDate) : m.viewedDate
            }))
          }))
        }
      }
      return response;
    })
  )
}
