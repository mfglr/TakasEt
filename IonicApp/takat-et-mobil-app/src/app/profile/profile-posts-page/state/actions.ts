import { createAction, props } from "@ngrx/store";

export const changeStartPostId = createAction(
  "[Profile Posts Page Store]",
  props<{startPostId : number}>()
)
