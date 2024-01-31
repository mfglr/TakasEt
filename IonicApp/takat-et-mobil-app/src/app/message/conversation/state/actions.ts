import { createAction, props } from "@ngrx/store";
import { MessageResponse } from "src/app/models/responses/message-response";

export const saveMessageAction = createAction(
  "[Conversation Page Store] save message action",
  props<{request : MessageResponse}>()
)

