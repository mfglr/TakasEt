import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { State } from "./reducer";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { selectPosts } from "./selectors";
import { PostService } from "src/app/services/post.service";
import { filterAppEntityState } from "src/app/custom-operators/filter-app-entity-state";

@Injectable()
export class UserPageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private userPageStore : Store<State>
  ) {}

  nextPageOfPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        mergeMap(
          (action) => this.userPageStore.select(selectPosts({userId : action.userId})).pipe(
            filterAppEntityState(),
            mergeMap(x => this.postService.getPostsByUserId(action.userId,x.page)),
            mergeMap(response => of(
              nextPostsSuccessAction({payload : response,userId : action.userId})
            ))
          )
        )
      )
    }
  )

}
