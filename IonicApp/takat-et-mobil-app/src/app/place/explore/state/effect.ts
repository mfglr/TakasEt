import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPageAction, nextPageSuccessAction } from "./actions";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { selectExplorePageState } from "./selectors";
import { addPostsAction } from "src/app/states/post-state/actions";
import { addPostImagesAction } from "src/app/states/post-image-state/actions";
import { addProfileImagesAction } from "src/app/states/profile-image-state/actions";
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
      ofType(nextPageAction),
      mergeMap(
        action => this.explorePageStore.select(selectExplorePageState({postId : action.postId})).pipe(
          filter(x => x != undefined),
          first(),
          filter(x => !(x!.status)),
          mergeMap(
            x => this.postService.getExplorePagePosts(x!.initialPost.tags,x!.initialPost.categoryId,x!.page).pipe(
              mergeMap(
                response => of(
                    nextPageSuccessAction({postId : action.postId,payload : response}),
                    addPostsAction({payload : response}),
                    addPostImagesAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
                    addProfileImagesAction({images : response.map(x => x.profileImage)})
                )
              )
            )
          ),
        )
      ),
    )
  })
}
