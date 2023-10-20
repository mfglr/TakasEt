import { initialPageOfPosts, takeValueOfComments, takeValueOfPosts } from "../app-state";
import { createReducer, on } from "@ngrx/store";
import { nextPageOfCommentsSuccess, nextPageOfPostsSuccess, resetPageOfPosts, setSelectedCommentId, setSelectedPostId } from "./actions";
import { HomeState } from "./states";
import { adapter, createCommentStates, createPostStates } from "./adapter";

const initialState : HomeState = adapter.getInitialState({
  status : false,
  page : {...initialPageOfPosts},
  selectedId : undefined
})

export const homeReducer = createReducer(
  initialState,
  on(nextPageOfPostsSuccess, (state,action) : HomeState => {
    return {
      ...adapter.addMany(createPostStates(action.posts),state),
      status : action.posts.length < takeValueOfPosts,
      page : {...state.page,skip : state.page.skip + takeValueOfPosts}
    }
  }),
  on(resetPageOfPosts, (state) : HomeState => ({...state,page : {...initialPageOfPosts}})),
  on(setSelectedPostId,(state,action) : HomeState =>({...state,selectedId : action.postId})),

  on(nextPageOfCommentsSuccess,(state,action) : HomeState => {
    if(state.selectedId && state.entities[state.selectedId])
      return adapter.updateOne({
        id : state.selectedId,
        changes : {
          comments : {
            ...state.entities[state.selectedId]!.comments,
            entities : [
              ...state.entities[state.selectedId]!.comments.entities,
              ...createCommentStates(action.comments)
            ],
            status : action.comments.length < takeValueOfComments,
            page : {
              ...state.entities[state.selectedId]!.comments.page,
              skip : state.entities[state.selectedId]!.comments.page.skip + takeValueOfComments
            }
          }
        }
      },state)
    return state;
  }),
  on(setSelectedCommentId,(state,action) => {
    if(state.selectedId && state.entities[state.selectedId])
      return adapter.updateOne({
        id : state.selectedId,
        changes : {
          comments : {
            ...state.entities[state.selectedId]!.comments,
            selectedId : action.commentId
          }
        }
      },state)
    return state;
  })
)
