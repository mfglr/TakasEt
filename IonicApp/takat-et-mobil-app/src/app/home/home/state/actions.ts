import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { StoryResponse } from "src/app/models/responses/story-response";

export const nextPostsAction = createAction("[Home Page Store] next posts")
export const nextPostsSuccessAction = createAction(
  "[Home Page Store] next posts success",
  props<{payload : PostResponse[]}>()
)

export const nextStoriesAction = createAction("[Home Page Store] next stories");
export const nextStoriesSuccessAction = createAction(
  "[Home Page Store] next stories success",
  props<{stories : StoryResponse[]}>()
)
