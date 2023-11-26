import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AppFileService } from "src/app/services/app-file.service";
import { PostService } from "src/app/services/post.service";
import { loadNextPostImageAction, loadPostImageAction, loadPostImageSuccessAction, loadProfileImageAction, loadProfileImageSuccessAction, nextPageAction, nextPageSuccessAction, switchLikeStatusAction, switchLikeStatusSuccessAction } from "./actions";
import { filter, first, mergeMap, of} from "rxjs";
import { Store } from "@ngrx/store";
import { selectFilter,selectLikeStatus,selectNextPostImageIndex, selectPostImageId, selectPostImageStatus, selectProfileImageId, selectProfileImageStatus, selectStatus } from "./selectors";
import { initCommentModalStatesAction } from "../comment_modal_state/action";
import { PagePostState } from "./state";
import { Injectable } from "@angular/core";
import { UserPostLikingService } from "src/app/services/user-post-liking.service";

@Injectable()
export class PagePostEffect{

    constructor(
        private actions : Actions,
        private postService : PostService,
        private userPostLikingService : UserPostLikingService,
        private appFileService : AppFileService,
        private pagePostStore : Store<PagePostState>,
    ) {}
    
    nextPage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageAction),
            mergeMap(
                action => this.pagePostStore.select(selectStatus({ pageId :action.pageId})).pipe(
                    first(),
                    mergeMap(
                        status => this.pagePostStore.select(selectFilter({pageId : action.pageId})).pipe(
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
            mergeMap(action => this.pagePostStore.select(
                selectPostImageStatus({pageId: action.pageId,postId : action.postId,index : action.index})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(status => this.pagePostStore.select(
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

    loadNextPostImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadNextPostImageAction),
            mergeMap(
                action => this.pagePostStore.select(selectNextPostImageIndex({pageId : action.pageId,postId : action.postId})).pipe(
                    first(),
                    mergeMap(nextIndex => this.pagePostStore.select(
                        selectPostImageStatus({pageId: action.pageId,postId : action.postId,index : nextIndex})).pipe(
                            first(),
                            filter(status => !status),
                            mergeMap(status => this.pagePostStore.select(
                                selectPostImageId({pageId : action.pageId,postId : action.postId,index : nextIndex})).pipe(
                                    first(),
                                    mergeMap((id) => this.appFileService.getAppFile(id)),
                                    mergeMap(url => of(loadPostImageSuccessAction({
                                        pageId : action.pageId,
                                        postId : action.postId,
                                        index : nextIndex,
                                        url : url
                                    })))
                                )
                            )
                        )
                    ),
                )
            )
        )
    })
    
    loadProfileImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadProfileImageAction),
            mergeMap(
                action => this.pagePostStore.select(selectProfileImageStatus({ pageId : action.pageId,postId : action.postId})).pipe(
                    first(),
                    filter(status => !status),
                    mergeMap(
                        status => this.pagePostStore.select(selectProfileImageId({ pageId : action.pageId,postId : action.postId})).pipe(
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

    switchLikeStatus$ = createEffect( () => {
        return this.actions.pipe(
            ofType(switchLikeStatusAction),
            mergeMap(
                action => this.pagePostStore.select(
                    selectLikeStatus({pageId : action.pageId,postId : action.postId})
                ).pipe(
                    first(),
                    mergeMap(
                        status =>{
                            let obs
                            if(status)
                                obs = this.userPostLikingService.unlike(action.postId)
                            else
                                obs = this.userPostLikingService.like(action.postId)
                            return obs.pipe(
                                mergeMap(() => of(switchLikeStatusSuccessAction({
                                    pageId : action.pageId,postId : action.postId
                                })))
                            )
                        }
                    )
                )
            ),
            
        )
    })
    
}