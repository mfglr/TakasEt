import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction("next page of posts")
export const nextPageOfPostsSuccess = createAction("next page of posts success",props<{posts : PostResponse[]}>())