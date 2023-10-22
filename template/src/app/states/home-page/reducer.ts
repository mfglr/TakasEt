import { createReducer, on } from "@ngrx/store";
import { PostsState, initialPageOfPosts, takeValueOfComments, takeValueOfPosts } from "../app-states";
import { nextPageOfChildrenSuccess,nextPageOfCommentsSuccess, nextPageOfPostsSuccess, resetPageOfPosts, setSelectedCommentId, setSelectedPostId } from "./actions";
import { commentAdapter, commentChildrenAdapter, createCommentStates, createPostStates, postAdapter } from "../app-adapters";


export interface HomePageState{
  posts : PostsState;
  selectedPostId : string | undefined;
  selectedCommentId : string | undefined;
}

let initialState : HomePageState = {
  selectedCommentId : undefined,
  selectedPostId : undefined,
  posts : postAdapter.getInitialState({
    page : {...initialPageOfPosts},
    status : false
  })
}

export const homeReducer = createReducer(
  initialState,
  on(nextPageOfPostsSuccess, (state,action) : HomePageState => {
    return {
      ...state,
      posts : {
        ...postAdapter.addMany(createPostStates(action.posts),state.posts),
        status : action.posts.length < takeValueOfPosts,
        page : {...state.posts.page,skip : state.posts.page.skip + takeValueOfPosts}
      }
    }
  }),
  on(resetPageOfPosts, (state) : HomePageState => ({...state,posts : {...state.posts,page : {...initialPageOfPosts}}})),
  on(setSelectedPostId,(state,action) : HomePageState =>({...state, selectedPostId : action.postId})),
  on(nextPageOfCommentsSuccess,(state,action) : HomePageState => {
    if(state.selectedPostId){
      let selectedCommentsState = state.posts.entities[state.selectedPostId]!.comments;
      let page = selectedCommentsState.page;
      return{
        ...state,
        posts : postAdapter.updateOne(
          {
            id : state.selectedPostId,
            changes : {
              comments : {
                ...commentAdapter.addMany(createCommentStates(action.comments),selectedCommentsState),
                status : action.comments.length < takeValueOfComments,
                page : {...page,skip : page.skip + takeValueOfComments}
              }
            }
          },
          state.posts
        )
      }
    }
    return state;
  }),
  on(setSelectedCommentId,(state,action) : HomePageState =>({...state,selectedCommentId : action.commentId})),
  on(nextPageOfChildrenSuccess,(state,action) : HomePageState => {
    if(state.selectedPostId && state.selectedCommentId){
      let selectedCommentsState = state.posts.entities[state.selectedPostId]!.comments;
      let selectedChildrenState = selectedCommentsState.entities[state.selectedCommentId]!.children
      let page = selectedChildrenState.page;
      return{
        ...state,
        posts : postAdapter.updateOne({
          id : state.selectedPostId,
          changes : {
            comments : commentAdapter.updateOne({
              id : state.selectedCommentId,
                changes : {
                  children : {
                    ...commentChildrenAdapter.addMany(createCommentStates(action.comments),selectedChildrenState),
                    page : {...page,skip : page.skip + takeValueOfComments},
                    status : action.comments.length < takeValueOfComments
                  }
                }
              },
              selectedCommentsState
            )}
          },
          state.posts
        )
      }
    }
    return state;
  })
)
