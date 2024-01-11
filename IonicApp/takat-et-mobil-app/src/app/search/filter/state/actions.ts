import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const filterPostsByKeyAction = createAction(
  "[Filter Posts Page Store] filter posts by key",
  props<{key : string | undefined}>()
)
export const filterPostsByKeySuccessAction = createAction(
  "[Filter Posts Page Store] filter posts by key success",
  props<{key : string | undefined,payload : PostResponse[]}>()
)

export const filterPostsByCategoryIdsAction = createAction(
  "[Filter Posts Page Store] filter posts by categoryIds",
  props<{categoryIds : string|undefined}>()
)
export const filterPostsByCategoryIdsSuccessAction = createAction(
  "[Filter Posts Page Store] filter posts by categoryIds success",
  props<{categoryIds : string|undefined,payload : PostResponse[]}>()
)

export const nextPostsAction = createAction("[Filter Posts Page Store] next posts")
export const nextPostsSuccessAction = createAction(
  "[Filter Posts Page Store] next posts sucess",
  props<{payload : PostResponse[]}>()
)
