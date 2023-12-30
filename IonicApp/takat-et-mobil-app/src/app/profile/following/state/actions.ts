import { createAction, props } from "@ngrx/store";

export const changeActiveIndexAction = createAction(
  "[Profile following Page Store]",
  props<{activeTab : number}>()
)
