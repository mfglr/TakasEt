import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { HomeState } from "./reducer";
import { nextPageOfPosts, nextPageOfPostsSuccess,setPageOfPosts, setStatusOfPosts } from "./actions";
import { selectCurrentPageOfPosts, selectStatusOfPosts } from "./selectors";

@Injectable()
export class HomeEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private store : Store<HomeState>,
  ) {}

  nextPageOfPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfPosts),
        withLatestFrom(this.store.select(selectStatusOfPosts)),
        filter(([action,status]) => !status),
        withLatestFrom(this.store.select(selectCurrentPageOfPosts)),
        mergeMap(
          ([[action,status],page]) => this.postService.getPostsWithFirstImages(page).pipe(
            mergeMap(
              response => of(
                nextPageOfPostsSuccess({posts : response}),
                setStatusOfPosts( {count : response.length} ),
                setPageOfPosts()
              )
            )
          )
        )
      )
    }
  )
}
