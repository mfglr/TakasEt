import { createAction, props } from "@ngrx/store";

export const addAction = createAction("[Test] add",props<{data : number}>());
export const subscribeAction = createAction("[Test] subscribe");
export const removeAction = createAction("[Test] subscribeSuccess",props<{id : number}>())
