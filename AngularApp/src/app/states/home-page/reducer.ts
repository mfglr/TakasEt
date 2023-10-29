import { createReducer, on } from "@ngrx/store";
import { PostsState, initialPageOfPosts,takeValueOfPosts } from "../app-states";
import { nextPageOfChildrenSuccess,nextPageOfCommentsSuccess, nextPageOfPostLikersSuccess, nextPageOfPostsSuccess, resetPageOfPosts, setSelectedCommentId, setSelectedPostId } from "./actions";
import { createPostStates, postAdapter } from "../app-adapters";
import { PostsStateFunctions } from "../posts-state-functions";


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
    if(state.selectedPostId)
      return {...state, posts : PostsStateFunctions.loadComments(state.posts,action.comments,state.selectedPostId)}
    return state;
  }),
  on(setSelectedCommentId,(state,action) : HomePageState =>({...state,selectedCommentId : action.commentId})),
  on(nextPageOfChildrenSuccess,(state,action) : HomePageState => {
    if(state.selectedPostId && state.selectedCommentId)
      return {
        ...state,
        posts : PostsStateFunctions.loadChildComments(state.posts,action.comments,state.selectedPostId,state.selectedCommentId)
      }
    return state;
  }),

  on(nextPageOfPostLikersSuccess, (state,action) : HomePageState => {
    if(state.selectedPostId)
      return {
        ...state,
        posts : PostsStateFunctions.loadLikers(state.posts,action.likers,state.selectedPostId)
      }
    return state;
  })
)
