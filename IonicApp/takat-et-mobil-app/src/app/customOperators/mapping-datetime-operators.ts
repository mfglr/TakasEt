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
              updateDate : message.updateDate ? new Date(message.updateDate) : message.updateDate,
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
            updateDate : c.updateDate ? new Date(c.updateDate) : c.updateDate,
            messages : c.messages.map((m) : MessageResponse => ({
              ...m,
              createdDate : new Date(m.createdDate),
              updateDate : m.updateDate ? new Date(m.updateDate): m.updateDate,
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
