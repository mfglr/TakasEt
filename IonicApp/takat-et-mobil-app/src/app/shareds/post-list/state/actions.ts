import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const openModalAction = createAction("[Post Detail Modal] openModalAction",props<{post:PostResponse}>());
export const closeModalAction = createAction("[Post Detail Modal] closeModalAction")