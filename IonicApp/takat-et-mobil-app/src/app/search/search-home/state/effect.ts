import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextAbstractPostsAction, nextAbstractPostsSuccessAction } from "./action";
import { filter, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";
import { selectAbstarctPosts } from "./selector";
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
      ofType(nextAbstractPostsAction),
      mergeMap(
        () => this.searchHomePageStore.select(selectAbstarctPosts).pipe(
          filter(state => !state.isLastEntities),
          mergeMap(state => this.postService.getSearchPosts(state.page)),
          mergeMap(response => of(
            nextAbstractPostsSuccessAction({posts : response}),
            loadPostsSuccessAction({payload : response}),
            loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
            loadProfileImagesSuccessAction({images : response.map(x => x.userImage)})
          ))
        )
      )
    )
  })

}
