import { createReducer, on } from "@ngrx/store";
import { Page, takeValueOfPosts } from "src/app/states/app-states";
import { nextPageSuccessAction } from "./actions";

export interface ProfilePageState{
    postIds : number[];
    page : Page;
    status : boolean;
}

const initialState : ProfilePageState = {
    page : {
        lastId : undefined,
        skip : 0,
        take : takeValueOfPosts
    },
    postIds : [],
    status : false
}

export const profilePageReducer = createReducer(
    initialState,
    on(
        nextPageSuccessAction,
        (state,action) => ({
            postIds : [...state.postIds,...action.payload.map(x => x.id)],
            status : action.payload.length < takeValueOfPosts,
            page : {
                ...state.page,
                skip : state.page.skip + takeValueOfPosts,
                lastId : action.payload.length ? action.payload[action.payload.length - 1].id : undefined
            }
        })
    )
)