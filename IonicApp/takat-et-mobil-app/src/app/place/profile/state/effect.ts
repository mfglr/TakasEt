import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom} from "rxjs";
import { Store } from "@ngrx/store";
import { selectStatusAndPage } from "./selectors";
import { Injectable } from "@angular/core";
import { ProfilePageState } from "./reducer";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/profile-image-state/actions";
import { LoginState } from "src/app/states/login_state/reducer";
import { selectUserId } from "src/app/states/login_state/selectors";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";

@Injectable()
export class ProfilePageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private profilePageStore : Store<ProfilePageState>,
    private loginStore : Store<LoginState>
  ) {}

  nextPage$ = createEffect(() =>{
    return this.actions.pipe(
      ofType(nextPostsAction),
      withLatestFrom(
        this.profilePageStore.select(selectStatusAndPage),
        this.loginStore.select(selectUserId)
      ),
      filter(([action,x,userId]) => !x.status && userId != undefined),
      mergeMap(([action,x,userId]) => this.postService.getPostsByUserId(userId!,x.page)),
      mergeMap(
        response => {
          return of(
            nextPostsSuccessAction({payload : response}),
            loadPostsSuccessAction({payload : response}),
            loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c) => a.concat(c))}),
            loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
          )
        }
      )
    )
  })

}
