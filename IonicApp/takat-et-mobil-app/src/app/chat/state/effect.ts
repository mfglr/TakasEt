import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import {
  nextPageMessagesSuccessAction, nextPageMessagesAction, nextPageUsersAction,
  nextPageUsersSuccessAction, nextPageConversationsAction, nextPageConversationsSuccessAction,
  nextPageUsersFailedAction, loadConversationUserAction, loadConversationUserSuccessAction,
  createMessageAction, createMessageFailedAction, createMessageSuccessAction,
  loadMessageImageAction, loadMessageImageSuccessAction
} from "./actions";
import { filter, first, from, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { MessageService } from "../services/message.service";
import { UserService } from "src/app/services/user.service";
import { ChatState } from "./reducer";
import { ConversationService } from "../services/conversation-service";
import {
  selectConversationPagination, selectHubConnectionState, selectImageLoadStatus,
  selectMessagePagination, selectUserPagination
} from "./selectors";
import { FileService } from "src/app/services/file.service";
import { ChatHubService } from "src/app/services/chat-hub.service";
import { ContainerName } from "src/app/models/enums/containerNames";
import { AppResponse } from "src/app/models/responses/app-response";
import { MessageResponse } from "../models/responses/message-response";
import { mapDateTimeOfConversationResponses, mapDateTimesOfMessageResponse } from "src/app/helpers/mapping-datetime";
import { HubConnectionState } from "@microsoft/signalr";
import { ImageLoadingState } from "src/app/models/enums/image-loading-state";

@Injectable()
export class ChatEffect{

  constructor(
    private readonly actions : Actions,
    private readonly chatStore : Store<ChatState>,
    private readonly messageService : MessageService,
    private readonly userService : UserService,
    private readonly conversationService : ConversationService,
    private readonly fileService : FileService,
    private readonly chatHub : ChatHubService
  ) {}

  createMessage$ = createEffect(
    () => this.actions.pipe(
      ofType(createMessageAction),
      mergeMap(
        action => this.chatStore.select(selectHubConnectionState).pipe(
          filter(hubConnectionState => hubConnectionState == HubConnectionState.Connected),
          first(),
          mergeMap(
            () => {
              if(action.paths.length > 0)
                return this.fileService.uploadImageFiles(action.paths,ContainerName.messageImages).pipe(
                  mergeMap(response => {
                    if(response.isError)
                      return of(createMessageFailedAction({id : action.message.id}))
                    return from(this.chatHub.hubConnection!.invoke("CreateMessage",{
                      ...action.message,
                      images : response.data!
                    }))
                    .pipe(
                      mergeMap((message : AppResponse<MessageResponse>) => {
                        if(message.isError)
                          return of(createMessageFailedAction({id : action.message.id}))
                        return of(createMessageSuccessAction({
                          payload : mapDateTimesOfMessageResponse(message.data!),
                          userState : action.userState
                        }))
                      })
                    )
                  })
                )
              return from(this.chatHub.hubConnection!.invoke("CreateMessage",{...action.message})).pipe(
                mergeMap((message : AppResponse<MessageResponse>) => {
                  if(message.isError)
                    return of(createMessageFailedAction({id : action.message.id}))
                  return of(createMessageSuccessAction({
                    payload : mapDateTimesOfMessageResponse(message.data!),
                    userState : action.userState
                  }))
                })
              )
            }
          )
        )
      )
    )
  )

  nextPageUsers$ = createEffect(
    () => this.actions.pipe(
      ofType(nextPageUsersAction),
      withLatestFrom(this.chatStore.select(selectUserPagination)),
      filter(([action,state]) => !state.isLast),
      mergeMap(([action,state]) => this.userService.getFollowersOrFollowings({...state})),
      mergeMap(response => {
        if(!response.isError)
          return of(nextPageUsersSuccessAction({payload : response.data!}))
        return of(nextPageUsersFailedAction({payload : response}))
      })
    )
  )

  loadConversationUser$ = createEffect(
    () => this.actions.pipe(
      ofType(loadConversationUserAction),
      mergeMap(action => this.userService.getUserById({userId : action.userId})),
      mergeMap(response => {
        if(!response.isError)
          return of(loadConversationUserSuccessAction({payload : response.data!}))
        return of()
      })
    )
  )

  nextPageConversations$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageConversationsAction),
        withLatestFrom(this.chatStore.select(selectConversationPagination)),
        filter(([action,state]) => !state.isLast),
        mergeMap(([action,state]) => this.conversationService.getConversations({...state})),
        mergeMap(response => of(nextPageConversationsSuccessAction({
          payload : mapDateTimeOfConversationResponses(response.data!)
        })))
      )
    }
  )

  nextPageMessages$ = createEffect(
    () => this.actions.pipe(
      ofType(nextPageMessagesAction),
      mergeMap(
        (action) => this.chatStore.select(selectMessagePagination({userId : action.user.id})).pipe(
          first(),
          filter(state => !state.isLast),
          mergeMap(state => this.messageService.getMessages({...state,userId : action.user.id})),
          mergeMap(response => {
            if(!response.isError)
              return of(nextPageMessagesSuccessAction({user : action.user,payload : response.data!}))
            return of()
          })
        )
      )
    )
  )

  loadMessageImage$ = createEffect(
    () => this.actions.pipe(
      ofType(loadMessageImageAction),
      mergeMap(
        action => this.chatStore.select(selectImageLoadStatus({index : action.imageIndex,messageId : action.id})).pipe(
          filter(status => status != ImageLoadingState.loaded),
          mergeMap(
            () => this.fileService.downloadFile(ContainerName.messageImages,action.blobName,action.extention).pipe(
              mergeMap(response => of(loadMessageImageSuccessAction({id : action.id,imageIndex : action.imageIndex,url : response})))
            )
          )
        )
      )
    )
  )
}
