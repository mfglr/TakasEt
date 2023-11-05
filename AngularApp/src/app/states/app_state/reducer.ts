import { createReducer, on } from "@ngrx/store";
import { AppState, HOME_PAGE_STATE, initialPageOfPosts } from "./app-states";
import { postAdapter } from "./app-adapters";
import { changeActivePageAction } from "./actions";


export const initialState : AppState = {
    activePage : HOME_PAGE_STATE,
    homePageState : {
        posts : postAdapter.getInitialState({
            status : false,
            page : {...initialPageOfPosts}
        }),
        selectedPostId : undefined,
        selectedCommentId : undefined
    },
    searchPageState : {
        posts : postAdapter.getInitialState({
            status : false,
            page : {...initialPageOfPosts} 
        }),
        selectedPostId : undefined
    }
}


export const appReducer = createReducer(
    initialState,
    on(changeActivePageAction,(state,action) : AppState => ({...state, activePage : action.activePage}) )
)