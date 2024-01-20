import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { CategoryResponse } from "src/app/models/responses/CategoryReponse";
import { nextCategoriesSuccessAction } from "./actions";
import { Page, takeValueOfCategories } from "../app-entity-state/app-entity-state";

export interface CategoryEntityState extends EntityState<CategoryResponse>{
  isLastEntities : boolean,
  page : Page
}

const adapter = createEntityAdapter<CategoryResponse>({selectId : state => state.id})
const initialState : CategoryEntityState = adapter.getInitialState({
  isLastEntities : false,
  page : {
    lastId : undefined,
    take : takeValueOfCategories
  }
})

export const selectAll = adapter.getSelectors().selectAll

export const categoryEntityReducer = createReducer(
  initialState,
  on(
    nextCategoriesSuccessAction,
    (state,action) => ({
      ...adapter.addMany(action.payload,state),
      isLastEntities : action.payload.length < takeValueOfCategories,
      page : {
        lastId : action.payload.length > 0 ? action.payload[action.payload.length - 1].id : state.page.lastId,
        take : takeValueOfCategories
      },
    })
  )
)
