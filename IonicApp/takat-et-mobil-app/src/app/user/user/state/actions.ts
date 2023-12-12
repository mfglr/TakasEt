import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const changeActiveTabAction = createAction(
  "[User Page State] changeActiveTabAction",
  props<{userId : number,activeTab : number}>()
)
export const initUserPageStateAction = createAction(
  "[User Page State] initUserPageState",
  props<{userId : number}>()
);
export const nextPostsAction = createAction(
  "[User Page State] nextPageOfPosts",
  props<{userId : number}>()
)
export const nextPostsSuccessAction = createAction(
  "[User Page State] nextPageOfPostsSuccessAction",
  props<{userId : number,payload : PostResponse[]}>()
)
