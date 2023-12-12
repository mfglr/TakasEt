import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { PostService } from "src/app/services/post.service";
import { nextPostsActions, nextPostsSuccessAction, nextSwappedPostsAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { State } from "./reducer";
import { selectPosts } from "./selectors";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/profile-image-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { filterAppEntityState } from "src/app/custom-operators/filter-app-entity-state";

@Injectable()
export class UserModuleEffect{
  constructor(
    private actions : Actions,
    private postService: PostService,
    private userModulStore: Store<State>
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsActions),
        mergeMap(
          action => this.userModulStore.select(selectPosts({userId : action.userId})).pipe(
            filterAppEntityState(),
            mergeMap(x => this.postService.getPostsByUserId(action.userId,x.page)),
            mergeMap(response => of(
              nextPostsSuccessAction({userId : action.userId,payload : response}),
              loadPostsSuccessAction({payload : response}),
              loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
              loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
            ))
          )
        )
      )
    }
  )

  nextSwappedPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextSwappedPostsAction),
        mergeMap(
          action => this.userModulStore.select(selectPosts({userId : action.userId})).pipe()
        )
      )
    }
  )

}
