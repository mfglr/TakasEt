import { createAction, props } from "@ngrx/store";

export const loadProfileImageAction = createAction(
    "[Profile Image State] loadProfileImage",
    props<{id : number}>()
);
export const loadProfileImageSuccessAction = createAction(
    "[Profile Image State] loadProfileImageSuccess",
    props<{id : number,url : string}>()
)