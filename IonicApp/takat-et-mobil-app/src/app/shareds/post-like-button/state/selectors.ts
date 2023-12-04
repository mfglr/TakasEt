import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntityPostLikeState } from "./reducer";

const selectPostLikeStore = createFeatureSelector<EntityPostLikeState>("PostLikeStore")

export const selectPostLikeState = (props : {postId : number}) => createSelector(
    selectPostLikeStore,
    state => state.entities[props.postId]!
)
export const selectLikeStatus = (props : {postId : number}) => createSelector(
    selectPostLikeState(props),
    state => state.likeStatus
)
export const selectLastComittedValue = (props : {postId : number}) => createSelector(
    selectPostLikeState(props),
    state => state.lastComittedValue
)
export const selectCountOfLikes = (props : {postId : number}) => createSelector(
    selectPostLikeState(props),
    state => state.countOfLikes
)