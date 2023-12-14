import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { PostService } from "src/app/services/post.service";
import { nextNotSwappedPostsAction, nextNotSwappedPostsSuccessAction, nextPostsAction, nextPostsSuccessAction, nextSwappedPostsAction, nextSwappedPostsSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { selectNotSwappedPosts, selectPosts, selectSwappedPosts } from "./selectors";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/profile-image-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { filterAppEntityState } from "src/app/custom-operators/filter-app-entity-state";
import { UserModuleCollectionState } from "./reducer";

@Injectable()
export class UserModuleCollectionEffect{
  constructor(
    private actions : Actions,
    private postService: PostService,
    private userModuleCollectionStore: Store<UserModuleCollectionState>
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        mergeMap(
          action => this.userModuleCollectionStore.select(selectPosts({userId : action.userId})).pipe(
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
          action => this.userModuleCollectionStore.select(selectSwappedPosts({userId : action.userId})).pipe(
            filterAppEntityState(),
            mergeMap(x => this.postService.getSwappedPosts(action.userId,x.page)),
            mergeMap(response => of(
              nextSwappedPostsSuccessAction({userId : action.userId,payload : response}),
              loadPostsSuccessAction({payload : response}),
              loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
              loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
            ))
          )
        )
      )
    }
  )

  nextNotSwappedPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextNotSwappedPostsAction),
        mergeMap(
          action => this.userModuleCollectionStore.select(selectNotSwappedPosts({userId : action.userId})).pipe(
            filterAppEntityState(),
            mergeMap(x => this.postService.getNotSwappedPosts(action.userId,x.page)),
            mergeMap(response => of(
              nextNotSwappedPostsSuccessAction({userId : action.userId,payload : response}),
              loadPostsSuccessAction({payload : response}),
              loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
              loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
            ))
          )
        )
      )
    }
  )

}
