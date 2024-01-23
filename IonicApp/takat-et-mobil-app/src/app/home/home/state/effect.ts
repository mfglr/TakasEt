import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { HomePageState } from "./reducer";
import { loadUserAction, loadUserSuccessAction, nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { selectPosts } from "./selectors";
import { loadPostImagesByPostResponsesSuccessAction, loadUserImageSuccessAction, loadUserImagesByPostResponsesSuccessAction } from "src/app/states/actions";
import { AppState } from "src/app/states/reducer";
import { selectUserId } from "src/app/states/selector";
import { UserService } from "src/app/services/user.service";

@Injectable()
export class HomePageEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private userService : UserService,
    private homePageStore : Store<HomePageState>,
    private appStore : Store<AppState>
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        withLatestFrom(
          this.homePageStore.select(selectPosts),
          this.appStore.select(selectUserId)
        ),
        filter(([action,state,userId]) => !state.isLastEntities && userId != undefined),
        mergeMap(([action,state,userId]) => this.postService.getHomePagePosts(userId!,state.page)),
        mergeMap(response => of(
          nextPostsSuccessAction({payload : response}),
          loadPostImagesByPostResponsesSuccessAction({payload : response}),
          loadUserImagesByPostResponsesSuccessAction({payload : response})
        ))
      )
    }
  )

  loadUser$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadUserAction),
        withLatestFrom(this.appStore.select(selectUserId)),
        filter(([action,userId]) => userId != undefined),
        mergeMap(([action,userId]) => this.userService.getUser(userId!)),
        mergeMap(response => of(
          loadUserSuccessAction({payload : response}),
          loadUserImageSuccessAction({userImageId : response.userImage?.id})
        ))
      )
    }
  )

}
