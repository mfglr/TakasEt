import { createAction, props } from "@ngrx/store";
import { UserImageResponse } from "src/app/models/responses/profile-image-response";

export const loadUserImageSuccessAction = createAction(
    "[Profile Image Store] addProfileImage",
    props<{image : UserImageResponse | null | undefined}>()
)
export const loadUserImagesSuccessAction = createAction(
    "[Profile Image Store] addProfileImages",
    props<{images : (UserImageResponse | null | undefined)[]}>()
)
export const loadUserImageUrlAction = createAction(
    "[Profile Image State] loadProfileImage",
    props<{id : number}>()
);
export const loadUserImageUrlSuccessAction = createAction(
    "[Profile Image State] loadProfileImageSuccess",
    props<{id : number,url : string}>()
)
