import { createAction, props } from "@ngrx/store";
import { CategoryResponse } from "src/app/models/responses/CategoryReponse";

export const nextCategoriesAction = createAction("[Category Enitity Store] next categories");
export const nextCategoriesSuccessAction = createAction(
  "[Category Enitity Store] next categories success",
  props<{payload : CategoryResponse[]}>()
);
