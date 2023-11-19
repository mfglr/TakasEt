import { createReducer, on } from "@ngrx/store";
import { initialPageOfPosts, takeValueOfPosts } from "../app-states";
import { nextPageOfPostsSuccess, loadPostImageSuccess,setCurrentIndex, loadProfileImageSuccess} from "./actions";
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
        loadPostImageSuccess,
        (state,action) => {
            let urls = [...state.posts.entities[action.postId]!.postImages]
            urls[action.index] = { url : action.url,isLoad : true};
            return {
                ...state,
                posts : postStateAdapter.updateOne({
                    id : action.postId,
                    changes : { postImages : urls }
                },state.posts)
            }
        }
    ),
    on(
        setCurrentIndex,
        (state,action) => {
            return {
                ...state,
                posts : postStateAdapter.updateOne({
                    id : action.postId,
                    changes : {currentIndex : action.index}
                },state.posts)
            }
        }
    ),
    on(
        loadProfileImageSuccess,
        (state,action) => {
            return {
                ...state,
                posts : postStateAdapter.updateOne({
                    id : action.postId,
                    changes : { profileImage : { url : action.url,isLoad : true} }
                },state.posts)
            }
        }
    )
)