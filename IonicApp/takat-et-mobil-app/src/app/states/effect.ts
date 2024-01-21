import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserImageService } from "../services/user-image.service";
import { PostImageService } from "../services/post-image.service";
import { LoginService } from "../services/login.service";
import { PostService } from "../services/post.service";
import { UserService } from "../services/user.service";
import { loadPostImagesSuccessAction, nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectPosts, selectUserId } from "./selector";
import { AppState } from "./reducer";
import { Store } from "@ngrx/store";

@Injectable()
export class AppEffect{

  constructor(
    private actions : Actions,
    private appStore : Store<AppState>,
    private userImageService : UserImageService,
    private postImageService : PostImageService,
    private loginService : LoginService,
    private postService : PostService,
    private userService : UserService
  ) {}

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        withLatestFrom(
          this.appStore.select(selectPosts),
          this.appStore.select(selectUserId)
        ),
        filter( ([action,state,userId]) => !state.isLastEntities && userId != undefined ),
        mergeMap( ([action,state,userId]) => this.postService.getUserPosts(userId!,state.page) ),
        mergeMap(response => of(
          nextPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({
            postImageIds :
              response.length > 0 ?
                response.map(x => x.postImages.map(x => x.id)).reduce((prev,cur) => cur.concat(prev)) :
                []
          })

        ))
      )
    }
  )


}
