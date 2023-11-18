import { createReducer, on } from "@ngrx/store";
import { initialPageOfPosts, takeValueOfPosts } from "../app-states";
import { nextPageOfPostsSuccess, loadImageSuccess,setCurrentIndex} from "./actions";
import { HomePageState, createPostStates, postStateAdapter } from "./state";


const initialState : HomePageState = {
    posts : postStateAdapter.getInitialState({
        page : {...initialPageOfPosts},
        status : false
    }),
}

export const homePageReducer = createReducer(
    initialState,
    on(
        nextPageOfPostsSuccess,
        (state,action) =>({
            ...state,
            posts : {
                ...postStateAdapter.addMany(createPostStates(action.posts),state.posts),
                page : {
                    ...state.posts.page,
                    skip : state.posts.page.skip + takeValueOfPosts,
                },
                status : action.posts.length < takeValueOfPosts
            }
        })
    ),
    on(
        loadImageSuccess,
        (state,action) => {
            let urls = [...state.posts.entities[action.postId]!.urls]
            urls[action.index] = { url : action.url,isLoad : true};
            return {
                ...state,
                posts : postStateAdapter.updateOne({ id : action.postId,changes : { urls : urls } },state.posts)
            }
        }
    ),
    on(
        setCurrentIndex,
        (state,action) => {
            return {
                ...state,
                posts : postStateAdapter.updateOne({id : action.postId,changes : {currentIndex : action.index}},state.posts)
            }
            
        }
    ),
)