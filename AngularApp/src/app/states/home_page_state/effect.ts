import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { selectPostImageStatus, selectPageOfPosts, selectPostImageId, selectStatusOfPosts, selectProfileImageStatus, selectProfileImageId } from "./selectors";
import { loadPostImage,loadPostImageSuccess,loadProfileImage,loadProfileImageSuccess,nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
import { initCommentModalStatesAction } from "../comment_modal_state/action";
import { AppFileService } from "src/app/services/app-file.service";
import { HomePageState } from "./state";

@Injectable()
export class HomePageEffect{
    constructor(
        private actions : Actions,
        private postService : PostService,
        private store : Store<HomePageState>,
        private appfileService : AppFileService
    ) {}

    nextPageOfPosts$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageOfPosts),
            withLatestFrom(
                this.store.select(selectStatusOfPosts),
                this.store.select(selectPageOfPosts)
            ),
            filter(([action,status,page]) => !status),
            mergeMap(([action,status,page]) => this.postService.getPostsByFollowedUsers(page).pipe(
                mergeMap(
                    response =>of(
                        nextPageOfPostsSuccess({ posts : response}),
                        initCommentModalStatesAction({postIds : response.map(x => x.id)})
                    )
                )
            ))
        )
    })

    loadPostImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadPostImage),
            mergeMap(
                action => this.store.select(selectPostImageStatus({postId : action.postId,index : action.index})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(
                        status => this.store.select(selectPostImageId({postId : action.postId,index : action.index})).pipe(
                        first(),
                        mergeMap((id) => this.appfileService.getAppFile(id)),
                        mergeMap( url => of( loadPostImageSuccess({postId : action.postId,index : action.index,url : url}) ) )
                    ))
                )
            ),
        )
    })

    loadProfileImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadProfileImage),
            mergeMap(
                action => this.store.select(selectProfileImageStatus({postId : action.postId})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(
                        status => this.store.select(selectProfileImageId({postId : action.postId})).pipe(
                            first(),
                            mergeMap((id) => this.appfileService.getAppFile(id)),
                            mergeMap( url => of( loadProfileImageSuccess({postId : action.postId,url : url})))
                        )
                    )
                )
            )
        )
    })
}