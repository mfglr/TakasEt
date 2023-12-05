import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const openModalAction = createAction("[App State] openModalAction",props<{post:PostResponse}>());
export const closeModalAction = createAction("[App State] closeModalAction")