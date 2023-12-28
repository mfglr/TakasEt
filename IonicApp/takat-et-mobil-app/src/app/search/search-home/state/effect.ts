import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction } from "./action";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";
import { selectPosts } from "./selector";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/user-image-entity-state/actions";

@Injectable()
export class SearchHomePageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private searchHomePageStore : Store<SearchHomePageState>
  ) {}

  nextPosts$ = createEffect(() => {
    return this.actions.pipe(
      ofType(nextPostsAction),
      mergeMap(
        () => this.searchHomePageStore.select(selectPosts).pipe(
          first(),
          filter(state => !state.isLastEntities),
          mergeMap(state => this.postService.getSearchPagePosts(state.page)),
          mergeMap(response => of(
            nextPostsSuccessAction({posts : response}),
            loadPostsSuccessAction({payload : response}),
            loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
            loadProfileImagesSuccessAction({images : response.map(x => x.userImage)})
          ))
        )
      )
    )
  })

}
