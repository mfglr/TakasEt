import { ConversationResponse } from "src/app/models/responses/conversation-response";
import { AppEntityState } from "src/app/state/app-entity-state/app-entity-state";

export interface MessageHomePageState{
  conversations : AppEntityState<ConversationResponse>;
}
