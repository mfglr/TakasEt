import { createAction, props } from "@ngrx/store";

export const changeActiveTabAction = createAction( "[Profile Page Store] change active tab", props<{activeTab : number}>() )

