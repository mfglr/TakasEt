import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { Page } from "src/app/states/app-states";

export const initUserPostsPageStateAction = createAction(
  "[User Posts Page Store] init user posts state",
  props<{userId : number,postIds : number[],page : Page,status : boolean}>()
)
export const nextPageAction = createAction(
  "[User Posts Page Store] next page action",
  props<{userId : number}>()
)
export const nextPageSuccessAction = createAction(
  "[User Posts Page Store] next page success action",
  props<{userId : number,posts : PostResponse[]}>()
)
