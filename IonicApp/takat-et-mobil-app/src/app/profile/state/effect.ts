import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { PostService } from "src/app/services/post.service";
import { nextNotSwappedPostsAction, nextNotSwappedPostsSuccessAction, nextPostsAction, nextPostsSuccessAction, nextSwappedPostsAction, nextSwappedPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectNotSwappedPosts, selectPosts, selectSwappedPosts } from "./selectors";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/profile-image-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { ProfileModuleState } from "./reducer";
import { LoginState } from "src/app/states/login_state/reducer";
import { selectUserId } from "src/app/states/login_state/selectors";

@Injectable()
export class ProfileModuleEffect{
  constructor(
    private actions : Actions,
    private postService: PostService,
    private loginStore : Store<LoginState>,
    private profileModuleStore: Store<ProfileModuleState>,
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        withLatestFrom(
          this.loginStore.select(selectUserId),
          this.profileModuleStore.select(selectPosts)
        ),
        filter(([action,userId,state]) => userId != undefined && !state.isLastEntities),
        mergeMap(([action,userId,state]) =>  this.postService.getPostsByUserId(userId!,state.page)),
        mergeMap(response => of(
          nextPostsSuccessAction({payload : response}),
          loadPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
          loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
        ))
      )
    }
  )

  nextSwappedPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextSwappedPostsAction),
        withLatestFrom(
          this.loginStore.select(selectUserId),
          this.profileModuleStore.select(selectSwappedPosts)
        ),
        filter(([action,userId,state]) => userId != undefined && !state.isLastEntities),
        mergeMap(([action,userId,state]) =>  this.postService.getSwappedPosts(userId!,state.page)),
        mergeMap(response => of(
          nextSwappedPostsSuccessAction({payload : response}),
          loadPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
          loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
        ))
      )
    }
  )

  nextNotSwappedPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextNotSwappedPostsAction),
        withLatestFrom(
          this.loginStore.select(selectUserId),
          this.profileModuleStore.select(selectNotSwappedPosts)
        ),
        filter(([action,userId,state]) => userId != undefined && !state.isLastEntities),
        mergeMap(([action,userId,state]) =>  this.postService.getNotSwappedPosts(userId!,state.page)),
        mergeMap(response => of(
          nextNotSwappedPostsSuccessAction({payload : response}),
          loadPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
          loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
        ))
      )
    }
  )

}
