import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPageAction, nextPageSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom} from "rxjs";
import { Store } from "@ngrx/store";
import { selectStatusAndPage } from "./selectors";
import { Injectable } from "@angular/core";
import { ProfilePageState } from "./reducer";
import { addPostsAction } from "src/app/states/post-state/actions";
import { addProfileImagesAction } from "src/app/states/profile-image-state/actions";
import { LoginState } from "src/app/states/login_state/reducer";
import { selectUserId } from "src/app/states/login_state/selectors";
import { addPostImagesAction } from "src/app/states/post-image-state/actions";

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
            ofType(nextPageAction),
            withLatestFrom(
                this.profilePageStore.select(selectStatusAndPage),
                this.loginStore.select(selectUserId)
            ),
            filter(([action,x,userId]) => !x.status && userId != undefined),
            mergeMap(([action,x,userId]) => this.postService.getPostsByUserId(userId!,x.page)),
            mergeMap(
                response => {
                    return of(
                        nextPageSuccessAction({payload : response}),
                        addPostsAction({payload : response}),
                        addPostImagesAction({postImages : response.map(x => x.postImages).reduce((a,c) => a.concat(c))}),
                        addProfileImagesAction({images : response.map(x => x.profileImage)})
                    )
                }
            )
        )
    })
   
}