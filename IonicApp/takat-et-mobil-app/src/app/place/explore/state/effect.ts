import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { selectExplorePageState } from "./selectors";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/user-image-entity-state/actions";
import { State } from "./reducer";

@Injectable()
export class ExplorePageEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private explorePageStore : Store<State>,
  ) {}

  nextPage$ = createEffect(() =>{
    return this.actions.pipe(
      ofType(nextPostsAction),
      mergeMap(
        action => this.explorePageStore.select(selectExplorePageState({postId : action.postId})).pipe(
          filter(x => x != undefined),
          first(),
          filter(x => !(x!.posts.isLastEntities)),
          mergeMap(
            x => this.postService.getExplorePagePosts(x!.initialPost.tags,x!.initialPost.categoryId,x!.posts.page).pipe(
              mergeMap(
                response => of(
                  nextPostsSuccessAction({postId : action.postId,payload : response}),
                  loadPostsSuccessAction({payload : response}),
                  loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
                  loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
                )
              )
            )
          ),
        )
      ),
    )
  })
}
