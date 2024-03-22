import { createAction, props } from "@ngrx/store";

export const addImageAction = createAction("[Message Image State] add image",props<{url : string | undefined}>());
export const removeImageAction = createAction("[Message Image State] remove image",props<{index : number}>());
export const removeAllImagesAction = createAction("[Message Image State] remove all images");
