import { createFeatureSelector, createSelector } from "@ngrx/store";
import { PostState } from "./reducer";

const selectStore = createFeatureSelector<PostState>("PostStore")
export const selectPostResponse = (props : {postId : number}) => createSelector(
    selectStore,
    state => state.entities[props.postId]
)