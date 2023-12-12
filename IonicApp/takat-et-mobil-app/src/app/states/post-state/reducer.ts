import { createReducer, on } from "@ngrx/store";
import { loadPostsSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export interface PostState extends EntityState<PostResponse>{}

const adapter = createEntityAdapter<PostResponse>({selectId : state => state.id})

export const selectAll = adapter.getSelectors().selectAll

export const postReducer = createReducer(
    adapter.getInitialState(),
    on( loadPostsSuccessAction, (state,action) => adapter.setMany(action.payload,state) ),
)
