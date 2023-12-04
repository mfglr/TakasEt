import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntityPostImageSliderState } from "./reducer";

const selectPostImageSliderStore = createFeatureSelector<EntityPostImageSliderState>("PostImageSliderStore")

export const selectPostImageState = (props : {postId : number,index : number}) => createSelector(
    selectPostImageSliderStore,
    (state) => state.entities[props.postId]?.postImages[props.index]
)
export const selectPostImageStates = (props : {postId : number}) => createSelector(
    selectPostImageSliderStore,
    state => state.entities[props.postId]!.postImages
)