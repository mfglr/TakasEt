import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import {loadPostsAction, loadUsersAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { loadUsersSuccessAction } from "./user-entity-state/actions";
import { loadUserImagesSuccessAction } from "./user-image-entity-state/actions";
import { loadPostsSuccessAction } from "./post-state/actions";
import { loadPostImagesSuccessAction } from "./post-image-state/actions";

@Injectable()
export class AppEffect{
  constructor(
    private actions : Actions
  ) {}

  loadPosts$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loadPostsAction),
      mergeMap(
        (action) => of(
          loadPostsSuccessAction({payload : action.posts}),
          loadPostImagesSuccessAction({
            postImages :
              action.posts.length > 0 ?
                action.posts.map(x => x.postImages).reduce((a,c)=>a.concat(c)) :
                []
          }),
          loadUserImagesSuccessAction({images : action.posts.map(x => x.userImage)})
        )
      )
    )
  })

  loadUsers$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loadUsersAction),
      mergeMap(
        action => of(
          loadUsersSuccessAction({users : action.users}),
          loadUserImagesSuccessAction({images : action.users.map(x=> x.userImage)})
        )
      )
    )
  })

}
