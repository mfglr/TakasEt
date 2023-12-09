import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserPostLikingService } from "src/app/services/user-post-liking.service";
import { commitAction, commitSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { PostLikeState } from "./reducer";
import { selectPostLikeState } from "./selectors";

@Injectable()
export class PostLikeEffect{
    constructor(
        private actions : Actions,
        private postLikeStore : Store<PostLikeState>,
        private likingService : UserPostLikingService
    ) {}

    commit$ = createEffect( () => {
        return this.actions.pipe(
            ofType(commitAction),
            mergeMap(
                action => this.postLikeStore.select(selectPostLikeState({postId : action.postId})).pipe(
                    first(),
                    filter(x => x.lastComittedValue != x.likeStatus),
                    mergeMap(
                        x => {
                            if(x.likeStatus)
                                return this.likingService.like(action.postId).pipe(
                                    mergeMap(
                                        () => of(commitSuccessAction({ postId : action.postId, value : x.likeStatus}))
                                    )
                                )
                            return this.likingService.unlike(action.postId).pipe(
                                mergeMap(
                                    () => of(commitSuccessAction({ postId : action.postId, value : x.likeStatus}))
                                )
                            )
                        }
                    )
                )
            )
        )
    })
}