import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { CategoryEntityState } from "./reducer";
import { nextCategoriesAction, nextCategoriesSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectPageAndStatus } from "./selectors";
import { CategoryService } from "src/app/services/category.service";
import { Injectable } from "@angular/core";

@Injectable()
export class EntityCategoryEffect{

  constructor(
    private actions : Actions,
    private categoryService : CategoryService,
    private entityCategoryStore : Store<CategoryEntityState>
  ) {}

    nextCategories$ = createEffect(
      () => {
        return this.actions.pipe(
          ofType(nextCategoriesAction),
          withLatestFrom( this.entityCategoryStore.select(selectPageAndStatus) ),
          filter(([action,state]) => !state.isLastEntities),
          mergeMap(([action,state]) => this.categoryService.getCategories(state.page)),
          mergeMap(response => of( nextCategoriesSuccessAction({payload : response}) ))
        )
      }
    )

}
