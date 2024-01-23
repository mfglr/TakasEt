import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { PostService } from "src/app/services/post.service";
import { nextFollowedsAction, nextFollowedsSuccessAction, nextFollowersAction, nextFollowersSuccessAction, nextNotSwappedPostsAction, nextNotSwappedPostsSuccessAction, nextPostsAction, nextPostsSuccessAction, nextSwappedPostsAction, nextSwappedPostsSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { selectFolloweds, selectFollowers, selectNotSwappedPosts, selectPosts, selectSwappedPosts } from "./selectors";
import { UserModuleCollectionState } from "./reducer";
import { UserService } from "src/app/services/user.service";

@Injectable()
export class UserModuleCollectionEffect{
  constructor(
    private actions : Actions,
    private postService: PostService,
    private userService : UserService,
    private userModuleCollectionStore: Store<UserModuleCollectionState>,
  ) {}

  // nextPosts$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(nextPostsAction),
  //       mergeMap(
  //         action => this.userModuleCollectionStore.select(selectPosts({userId : action.userId})).pipe(
  //           filterAppEntityState(),
  //           mergeMap(x => this.postService.getUserPosts(action.userId,x.page)),
  //           mergeMap(response => of(
  //             nextPostsSuccessAction({userId : action.userId,payload : response}),
  //             loadPostsSuccessAction({payload : response}),
  //             loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
  //             loadUserImagesSuccessAction({images : response.map(x => x.userImage)})
  //           ))
  //         )
  //       )
  //     )
  //   }
  // )

  // nextSwappedPosts$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(nextSwappedPostsAction),
  //       mergeMap(
  //         action => this.userModuleCollectionStore.select(selectSwappedPosts({userId : action.userId})).pipe(
  //           filterAppEntityState(),
  //           mergeMap(x => this.postService.getSwappedPosts(action.userId,x.page)),
  //           mergeMap(response => of(
  //             nextSwappedPostsSuccessAction({userId : action.userId,payload : response}),
  //             loadPostsSuccessAction({payload : response}),
  //             loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
  //             loadUserImagesSuccessAction({images : response.map(x => x.userImage)})
  //           ))
  //         )
  //       )
  //     )
  //   }
  // )

  // nextNotSwappedPosts$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(nextNotSwappedPostsAction),
  //       mergeMap(
  //         action => this.userModuleCollectionStore.select(selectNotSwappedPosts({userId : action.userId})).pipe(
  //           filterAppEntityState(),
  //           mergeMap(x => this.postService.getNotSwappedPosts(action.userId,x.page)),
  //           mergeMap(response => of(
  //             nextNotSwappedPostsSuccessAction({userId : action.userId,payload : response}),
  //             loadPostsSuccessAction({payload : response}),
  //             loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
  //             loadUserImagesSuccessAction({images : response.map(x => x.userImage)})
  //           ))
  //         )
  //       )
  //     )
  //   }
  // )

  // nextFollowers$ = createEffect(() => {
  //   return this.actions.pipe(
  //     ofType(nextFollowersAction),
  //     mergeMap(
  //       action => this.userModuleCollectionStore.select(selectFollowers({userId : action.userId})).pipe(
  //         filterAppEntityState(),
  //         mergeMap(x => this.userService.getFollowers(action.userId,x.page)),
  //         mergeMap(response => of(
  //           nextFollowersSuccessAction({userId : action.userId,payload : response}),
  //           loadUsersSuccessAction({users : response}),
  //           loadUserImagesSuccessAction({images : response.map(x => x.userImage)}),
  //         ))
  //       )
  //     )
  //   )
  // })

  // nextFolloweds$ = createEffect(() => {
  //   return this.actions.pipe(
  //     ofType(nextFollowedsAction),
  //     mergeMap(
  //       action => this.userModuleCollectionStore.select(selectFolloweds({userId : action.userId})).pipe(
  //         filterAppEntityState(),
  //         mergeMap(x => this.userService.getFolloweds(action.userId,x.page)),
  //         mergeMap(response => of(
  //           nextFollowedsSuccessAction({userId : action.userId,payload : response}),
  //           loadUsersSuccessAction({users : response}),
  //           loadUserImagesSuccessAction({images : response.map(x => x.userImage)}),
  //         ))
  //       )
  //     )
  //   )
  // })

}
