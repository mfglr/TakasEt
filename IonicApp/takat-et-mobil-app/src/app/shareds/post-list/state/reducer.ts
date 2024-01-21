import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { openModalAction, closeModalAction, changeFragmentId } from "./actions";

export interface PostListState{
  postOfModal : PostResponse | undefined;
  isModalOpen : boolean;
  fragmentId : number | undefined;
}
const initialState : PostListState = {
  postOfModal : undefined,
  isModalOpen : false,
  fragmentId : undefined
}

export const postListReducer = createReducer(
  initialState,
  on( openModalAction, (state,action) => ({...state, postOfModal : action.post,isModalOpen : true}) ),
  on( closeModalAction, (state) => ({...state, postOfModal : undefined,isModalOpen : false})),
  on(changeFragmentId,(state,action) => ({...state,fragmentId : action.fragmentId}))
)
