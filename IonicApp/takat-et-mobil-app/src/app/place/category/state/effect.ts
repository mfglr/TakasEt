import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { CategoryPageCollectionState } from "./reducer";
import { Store } from "@ngrx/store";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { selectPosts } from "./selectors";
import { filterAppEntityState } from "src/app/custom-operators/filter-app-entity-state";
import { loadPostsAction } from "src/app/states/actions";

@Injectable()
export class CategoryPageCollectionEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private categoryPageCollectionStore : Store<CategoryPageCollectionState>
  ) {}

  nextPosts$ = createEffect(() => {
    return this.actions.pipe(
      ofType(nextPostsAction),
      mergeMap(
        action => this.categoryPageCollectionStore.select(selectPosts({categoryId : action.categoryId})).pipe(
          filterAppEntityState(),
          mergeMap(state => this.postService.getPostsByCategoryId(action.categoryId,state.page)),
          mergeMap(response => of(
              nextPostsSuccessAction({categoryId : action.categoryId, payload : response}),
              loadPostsAction({posts : response})
          )))
      )
    )
  })
}
