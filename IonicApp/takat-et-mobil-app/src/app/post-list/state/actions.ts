import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const openModalAction = createAction("[Post List Store] openModalAction",props<{post:PostResponse}>());
export const closeModalAction = createAction("[Post List Store] closeModalAction")
export const changeFragmentId = createAction("[Post List Store]",props<{fragmentId : number}>())
