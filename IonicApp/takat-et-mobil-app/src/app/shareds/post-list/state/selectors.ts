import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State } from "./reducer";

const selectStore = createFeatureSelector<State>("PostListStore");
export const selectPostOfModal = createSelector(selectStore,state => state.postOfModal)
export const selectIsModalOpen = createSelector(selectStore,state => state.isOpenModal)