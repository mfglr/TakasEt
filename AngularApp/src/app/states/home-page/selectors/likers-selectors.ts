import { createSelector } from "@ngrx/store";
import { userAdapter } from "../../app-adapters";
import { UsersState } from "../../app-states";
import { selectHomePageState } from "./home-page-selectors";

const selectSelectedLikers = createSelector(
  selectHomePageState,
  state => {
    if(state.selectedPostId)
      return state.posts.entities[state.selectedPostId]?.likers
    return undefined;
  }
)
const selectSelectedUserStatesOfLikers = createSelector(
  selectSelectedLikers,
  userAdapter.getSelectors(
    (state : UsersState | undefined) => state ? state : userAdapter.getInitialState()
  ).selectAll
)
const selectLikers = (props : {postId : string}) => createSelector(
  selectHomePageState,
  state => state.posts.entities[props.postId]?.likers
)
const selectUserStatesOfLikers = (props : {postId : string}) => createSelector(
  selectLikers(props),
  userAdapter.getSelectors(
    (state : UsersState | undefined) => state ? state : userAdapter.getInitialState()
  ).selectAll
)
export const selectPageOfLikers = createSelector(selectSelectedLikers,state => state?.page)
export const selectStatusOfLikers = createSelector(selectSelectedLikers,state => state?.status)
export const selectUserReponsesOfLikers = (props : {postId : string}) => createSelector(
  selectUserStatesOfLikers(props),
  state => state.map(x => x.user)
)
export const selectSelectedUserResponsesOfLiker = createSelector(
  selectSelectedUserStatesOfLikers,
  state => state.map(x => x.user)
)
