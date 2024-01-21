import { createFeatureSelector, createSelector } from "@ngrx/store";
import { PostListState } from "./reducer";

const selectStore = createFeatureSelector<PostListState>("PostListStore");
export const selectPostOfModal = createSelector(selectStore,state => state.postOfModal)
export const selectIsModalOpen = createSelector(selectStore,state => state.isModalOpen)
export const selectPostId = createSelector(selectStore,state => state.fragmentId);
