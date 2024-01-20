import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { HomePageState } from "./reducer";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { selectPosts } from "./selectors";

@Injectable()
export class HomePageEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private homePageStore : Store<HomePageState>
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        withLatestFrom(this.homePageStore.select(selectPosts)),
        filter(([action,state]) => !state.isLastEntities),
        mergeMap(([action,state]) => this.postService.getHomePagePosts(state.page)),
        mergeMap(response => of( nextPostsSuccessAction({payload : response}) ))
      )
    }
  )
}
