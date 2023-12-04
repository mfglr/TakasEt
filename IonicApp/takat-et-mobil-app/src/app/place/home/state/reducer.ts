import { createReducer, on } from "@ngrx/store";
import { nextPageSuccessAction } from "./actions";
import { AppEntityState, takeValueOfPosts } from "src/app/states/app-states";
import { PostResponse } from "src/app/models/responses/post-response";
import { createEntityAdapter } from "@ngrx/entity";

interface EntityPostState extends AppEntityState<PostResponse>{}
export interface HomePageState{
    posts : EntityPostState
}
const adapter = createEntityAdapter<PostResponse>({selectId : state => state.id})
export const selectAll = adapter.getSelectors().selectAll

const initialState : HomePageState = {
    posts : adapter.getInitialState({
        status : false,
        page : {
            skip : 0,
            take : takeValueOfPosts,
            lastId : undefined
        }
    })
}
export const homePageReducer = createReducer(
    initialState,
    on(
        nextPageSuccessAction,
        (state,action) => ({
            ...state,
            posts : {
                ...adapter.addMany(action.payload,state.posts),
                status : action.payload.length < takeValueOfPosts,
                page : {
                    ...state.posts.page,
                    skip : state.posts.page.skip + takeValueOfPosts,
                    lastId : action.payload.length ? action.payload[action.payload.length - 1].id : undefined
                }
            },
        })
    ),
)