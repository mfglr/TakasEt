import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { AppEntityState, initialPageOfPosts, takeValueOfPosts } from "../app-states";
import { createEntityAdapter } from "@ngrx/entity";
import { nextPageOfPostsSuccess } from "./actions";

export interface HomePageState{
    posts : AppEntityState<PostResponse>;
}
export const postAdapter = createEntityAdapter<PostResponse>({
    selectId : state => state.id
})

const initialState : HomePageState = {
    posts : postAdapter.getInitialState({
        page : {...initialPageOfPosts},
        status : false
    })
}

export const homePageReducer = createReducer(
    initialState,
    on(
        nextPageOfPostsSuccess,
        (state,action) =>({
            ...state,
            posts : {
                ...postAdapter.addMany(action.posts,state.posts),
                page : {
                    ...state.posts.page,
                    skip : state.posts.page.skip + takeValueOfPosts,
                },
                status : action.posts.length < takeValueOfPosts
            }
        })
    )
)