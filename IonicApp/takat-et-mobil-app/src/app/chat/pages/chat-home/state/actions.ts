import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../models/responses/conversation-response";

export const nextPageConversationsAction = createAction(
  "[Chat Home Store] next page conversations"
);
export const nextPageConversationsSuccessAction = createAction(
  "[Chat Home Store] next page conversations success",
  props<{payload : ConversationResponse[]}>()
)
