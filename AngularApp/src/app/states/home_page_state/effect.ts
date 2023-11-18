import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { selectIsLoad, selectPageOfPosts, selectPostImageId, selectStatusOfPosts } from "./selectors";
import { loadImage,loadImageSuccess,nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
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

    loadImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadImage),
            mergeMap(
                action => this.store.select(selectIsLoad({postId : action.postId,index : action.index})).pipe(
                    first(),
                    filter(isLoad => !isLoad),
                    mergeMap(
                        isLoad => this.store.select(selectPostImageId({postId : action.postId,index : action.index})).pipe(
                        first(),
                        mergeMap((id) => this.appfileService.getAppFile(id)),
                        mergeMap( url => of( loadImageSuccess({postId : action.postId,index : action.index,url : url}) ) )
                    ))
                )
            ),
        )
    })
}