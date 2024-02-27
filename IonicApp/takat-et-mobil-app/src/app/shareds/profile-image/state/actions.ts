import { createAction, props } from "@ngrx/store";

export const loadUserImageAction = createAction(
  "[User Image Store] load user image",
  props<{id : string,containerName : string,blobName : string}>()
)
export const loadUserImageSuccessAction = createAction(
  "[user Image Store] load user image success",
  props<{id : string,url : string}>()
)
