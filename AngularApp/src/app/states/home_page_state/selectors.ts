import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState, postAdapter } from "./reducer";
import { AppEntityState } from "../app-states";
import { PostResponse } from "src/app/models/responses/post-response";

const selectHomePageState = createFeatureSelector<HomePageState>("HomePageState");
const selectPosts = createSelector(selectHomePageState,(state : HomePageState ) => state.posts)

export const selectPostResponses = createSelector(
    selectPosts,
    postAdapter.getSelectors((state : AppEntityState<PostResponse>) => state).selectAll
)
export const selectPageOfPosts = createSelector( selectPosts, state => state.page )
export const selectStatusOfPosts = createSelector( selectPosts, state => state.status )