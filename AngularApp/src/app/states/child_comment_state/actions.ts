import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const nextPageAction = createAction("[child comment] nextPageAction",props<{parentComment : CommentResponse}>())
export const nextPageActionSuccess = createAction(
    "[child comment] nextPageActionSuccess",
    props<{payload : CommentResponse[],parentComment : CommentResponse}>()
)
export const switchVisibilityAction = createAction( "[child comment] switchVisibility",props<{parentComentId : string}>())