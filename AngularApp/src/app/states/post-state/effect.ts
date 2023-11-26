import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AppFileService } from "src/app/services/app-file.service";
import { PostService } from "src/app/services/post.service";
import { loadPostImageAction, loadPostImageSuccessAction, loadProfileImageAction, loadProfileImageSuccessAction, nextPageAction, nextPageSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { selectFilter, selectPostImageId, selectPostImageStatus, selectProfileImageId, selectProfileImageStatus, selectStatus } from "./selectors";
import { initCommentModalStatesAction } from "../comment_modal_state/action";
import { PagePostState } from "./state";
import { Injectable } from "@angular/core";
@Injectable()
export class PagePostEffect{

    constructor(
        private actions : Actions,
        private postService : PostService,
        private appFileService : AppFileService,
        private store : Store<PagePostState>
    ) {}
    
    nextPage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageAction),
            mergeMap(
                action => this.store.select(selectStatus({ pageId :action.pageId})).pipe(
                    first(),
                    mergeMap(
                        status => this.store.select(selectFilter({pageId : action.pageId})).pipe(
                            first(),
                            filter( filter => !status ),
                            mergeMap(
                                filter => this.postService.getPostsByFilter(filter)
                            ),
                            mergeMap(
                                response => of(
                                    nextPageSuccessAction({ pageId: action.pageId,payload : response}),
                                    initCommentModalStatesAction({postIds : response.map(x => x.id)})
                                )
                            )
                        )
                    )
                )
            )
        )
    })
    
    loadPostImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadPostImageAction),
            mergeMap(action => this.store.select(
                selectPostImageStatus({pageId: action.pageId,postId : action.postId,index : action.index})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(status => this.store.select(
                        selectPostImageId({pageId : action.pageId,postId : action.postId,index : action.index})).pipe(
                            first(),
                            mergeMap((id) => this.appFileService.getAppFile(id)),
                            mergeMap(url => of(loadPostImageSuccessAction({
                                pageId : action.pageId,
                                postId : action.postId,
                                index : action.index,
                                url : url
                            })))
                        )
                    )
                )
            ),
        )
    })
    
    loadProfileImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadProfileImageAction),
            mergeMap(
                action => this.store.select(selectProfileImageStatus({ pageId : action.pageId,postId : action.postId})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(
                        status => this.store.select(selectProfileImageId({ pageId : action.pageId,postId : action.postId})).pipe(
                            first(),
                            mergeMap((id) => this.appFileService.getAppFile(id)),
                            mergeMap( url => of( loadProfileImageSuccessAction({
                                pageId: action.pageId,postId : action.postId,url : url
                            })))
                        )
                    )
                )
            )
        )
    })

}