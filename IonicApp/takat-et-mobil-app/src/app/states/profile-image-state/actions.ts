import { createAction, props } from "@ngrx/store";
import { ProfileImageResponse } from "src/app/models/responses/profile-image-response";

export const addProfileImageAction = createAction(
    "[Profile Image Store] addProfileImage",
    props<{image : ProfileImageResponse | null | undefined}>()
)
export const addProfileImagesAction = createAction(
    "[Profile Image Store] addProfileImages",
    props<{images : (ProfileImageResponse | null | undefined)[]}>()
)
export const loadProfileImageAction = createAction(
    "[Profile Image State] loadProfileImage",
    props<{id : number}>()
);
export const loadProfileImageSuccessAction = createAction(
    "[Profile Image State] loadProfileImageSuccess",
    props<{id : number,url : string}>()
)