import { AppState,initialPageOfPosts, takeValueOfPosts } from "../state";
import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { nextPageOfPostsSuccess, resetPageOfPosts,  setPageOfPosts, setSelectedPostId,  setStatusOfPosts } from "./actions";
import { createEntityAdapter } from "@ngrx/entity";

export interface HomeState extends AppState<PostResponse>{
}

export const adapter = createEntityAdapter<PostResponse>({
  selectId : (state) => state.id
})

const initialState : HomeState = adapter.getInitialState({
  status : false,
  page : {...initialPageOfPosts},
  selectedId : undefined
})

export const homeReducer = createReducer(
  initialState,
  on(nextPageOfPostsSuccess, (state,action) : HomeState => adapter.addMany(action.posts,state)),
  on(setStatusOfPosts, (state,action) : HomeState => ({...state,status : action.count < takeValueOfPosts})),
  on(setPageOfPosts, (state) : HomeState => ({...state,page : {...state.page,skip : state.page.skip + takeValueOfPosts}})),
  on(resetPageOfPosts, (state) : HomeState => ({...state,page : {...initialPageOfPosts}})),
  on(setSelectedPostId,(state,action) : HomeState =>({...state,selectedId : action.postId})),
)
