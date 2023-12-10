import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { State } from "./reducer";
import { nextPageOfPostsAction, nextPageOfPostsSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { selectUserPageState } from "./selectors";
import { PostService } from "src/app/services/post.service";

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
        ofType(nextPageOfPostsAction),
        mergeMap(
          (action) => this.userPageStore.select(selectUserPageState({userId : action.userId})).pipe(
            filter(x => x != undefined),
            first(),
            filter(x => !(x!.posts.status)),
            mergeMap(x => this.postService.getPostsByUserId(action.userId,x!.posts.page)),
            mergeMap(response => of(nextPageOfPostsSuccessAction({payload : response,userId : action.userId})))
          )
        )
      )
    }
  )

}
