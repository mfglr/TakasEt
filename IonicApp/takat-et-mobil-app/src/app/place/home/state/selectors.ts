import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState, selectAll } from "./reducer";

const selectPagePost = createFeatureSelector<HomePageState>("HomePageState");
const selectPosts = createSelector(selectPagePost,state => state.posts)
export const selectPostResponses = createSelector( selectPosts, state => selectAll(state) )
export const selectStatusAndPage = createSelector(
    selectPosts,
    state => ({ status : state.status,page : state.page})
)
