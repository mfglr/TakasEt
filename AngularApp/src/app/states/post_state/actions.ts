import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";


export const nextPageOfPosts = createAction("next page of posts")
export const nextPageOfPostsSuccess = createAction("next page of posts success",props<{queryId : string, posts : PostResponse[]}>())
export const setSelectedQueryId = createAction("set selected query id",props<{queryId : string}>())