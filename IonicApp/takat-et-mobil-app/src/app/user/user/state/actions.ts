import { createAction, props } from "@ngrx/store";

export const changeActiveTabAction = createAction(
  "[User Page State] changeActiveTabAction",
  props<{userId : number,activeTab : number}>()
)
export const initUserPageStateAction = createAction(
  "[User Page State] initUserPageState",
  props<{userId : number}>()
);

