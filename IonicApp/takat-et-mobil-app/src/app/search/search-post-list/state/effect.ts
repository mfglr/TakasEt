import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { EntitySearchPostListPageState } from "./reducer";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { selectPosts } from "./selectors";
import { filterAppEntityState } from "src/app/custom-operators/filter-app-entity-state";
import { loadPostsAction } from "src/app/states/actions";

@Injectable()
export class EntitySearchPostListPageEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private entitySearchPostListPageStore : Store<EntitySearchPostListPageState>
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        mergeMap(
          action => this.entitySearchPostListPageStore.select(selectPosts({postId : action.postId})).pipe(
            filterAppEntityState(),
            mergeMap(x => this.postService.getSearchPostListPagePosts(action.postId,x.page)),
            mergeMap(response => of(
              nextPostsSuccessAction({postId : action.postId,payload : response}),
              loadPostsAction({posts : response})
            ))
          )
        )
      )
    }
  )
}
