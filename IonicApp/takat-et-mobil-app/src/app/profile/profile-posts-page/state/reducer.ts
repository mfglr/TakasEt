import { createReducer, on } from "@ngrx/store";
import { changeStartPostId } from "./actions";

export interface ProfilePostsPageState{
  startPostId : number | undefined;
}

const initialState : ProfilePostsPageState = {
  startPostId : undefined
}

export const profilePostsPageReducer = createReducer(
  initialState,
  on(changeStartPostId,(state,action) => ({ startPostId : action.startPostId}))
)
