import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { PostService } from "src/app/services/post.service";
import { nextFollowedsAction, nextFollowedsSuccessAction, nextFollowersAction, nextFollowersSuccessAction, nextNotSwappedPostsAction, nextNotSwappedPostsSuccessAction, nextPostsAction, nextPostsSuccessAction, nextSwappedPostsAction, nextSwappedPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectFolloweds, selectFollowers, selectNotSwappedPosts, selectPosts, selectSwappedPosts } from "./selectors";
import { LoginState } from "src/app/states/login_state/reducer";
import { selectUserId } from "src/app/states/login_state/selectors";
import { UserService } from "src/app/services/user.service";
import { ProfileState } from "./reducer";
import { loadPostsAction, loadUsersAction } from "../actions";

@Injectable()
export class ProfileEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private userServie : UserService,
    private loginStore : Store<LoginState>,
    private profileModuleStore: Store<ProfileState>,
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
          loadPostsAction({posts : response})
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
          loadPostsAction({posts : response})
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
          loadPostsAction({posts : response})
        ))
      )
    }
  )

  nextFollowers$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextFollowersAction),
        withLatestFrom(
          this.profileModuleStore.select(selectUserId),
          this.profileModuleStore.select(selectFollowers)
        ),
        filter(([action,userId,state]) => userId != undefined && !state.isLastEntities),
        mergeMap(([action,userId,state]) =>  this.userServie.getFollowers(userId!,state.page)),
        mergeMap(response => of(
          nextFollowersSuccessAction({payload : response}),
          loadUsersAction({users : response})
        ))
      )
    }
  )

  nextFolloweds$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextFollowedsAction),
        withLatestFrom(
          this.profileModuleStore.select(selectUserId),
          this.profileModuleStore.select(selectFolloweds)
        ),
        filter(([action,userId,state]) => userId != undefined && !state.isLastEntities),
        mergeMap(([action,userId,state]) =>  this.userServie.getFolloweds(userId!,state.page)),
        mergeMap(response => of(
          nextFollowedsSuccessAction({payload : response}),
          loadUsersAction({users : response})
        ))
      )
    }
  )
}
