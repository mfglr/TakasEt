import { createAction, props } from "@ngrx/store";

export const changeActiveTabAction = createAction(
  "[Profile following Page Store]",
  props<{activeTab : number}>()
)
