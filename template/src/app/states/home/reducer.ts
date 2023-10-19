import { initialPageOfPosts, takeValueOfComments, takeValueOfPosts } from "../state";
import { createReducer, on } from "@ngrx/store";
import { nextPageOfCommentsSuccess, nextPageOfPostsSuccess, resetPageOfPosts,  setPageOfComments,  setPageOfPosts, setSelectedPostId,  setStatusOfComments,  setStatusOfPosts } from "./actions";
import { adapterOfComments, adapterOfHome } from "./adapters";
import { CommentsState, HomeState } from "./states";
import { createCommentStates, createPostStates } from "./creators";

const initialState : HomeState = adapterOfHome.getInitialState({
  status : false,
  page : {...initialPageOfPosts},
  selectedId : undefined
})

export const homeReducer = createReducer(
  initialState,
  on(nextPageOfPostsSuccess, (state,action) : HomeState => adapterOfHome.addMany(createPostStates(action.posts),state)),
  on(setStatusOfPosts, (state,action) : HomeState => ({...state,status : action.count < takeValueOfPosts})),
  on(setPageOfPosts, (state) : HomeState => ({...state,page : {...state.page,skip : state.page.skip + takeValueOfPosts}})),
  on(resetPageOfPosts, (state) : HomeState => ({...state,page : {...initialPageOfPosts}})),
  on(setSelectedPostId,(state,action) : HomeState =>({...state,selectedId : action.postId})),

  on(nextPageOfCommentsSuccess,(state,action) : HomeState => {
    if(state.selectedId && state.entities[state.selectedId])
      return adapterOfHome.updateOne({
        id : state.selectedId,
        changes : {
          comments : adapterOfComments.addMany(
            createCommentStates(action.comments),
            state.entities[state.selectedId!]!.comments
          )
        }
      },state)
    return state;
  }),
  on(setStatusOfComments,(state,action) : HomeState => {
    if(state.selectedId && state.entities[state.selectedId])
      return adapterOfHome.updateOne({
        id : state.selectedId,
        changes : {
          comments : {
            ...state.entities[state.selectedId]!.comments,
            status : action.count < takeValueOfComments
          }
        }
      },state)
    return state;
  }),
  on(setPageOfComments,(state,action) : HomeState => {
    if(state.selectedId && state.entities[state.selectedId])
      return adapterOfHome.updateOne({
        id : state.selectedId,
        changes : {
          comments : {
            ...state.entities[state.selectedId]!.comments,
            page : {
              ...state.entities[state.selectedId]!.comments.page,
              skip : state.entities[state.selectedId]!.comments.page.skip + takeValueOfComments
            }
          }
        }
      },state)
    return state;
  })
)
