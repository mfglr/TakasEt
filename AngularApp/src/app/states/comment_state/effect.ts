import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CommentService } from "src/app/services/comment.service";
import * as appCommentState from "./state";
import * as appCommentSelectors from "./selectors"
import * as appCommentActions from "./actions"
import { filter, first, map, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { Injectable } from "@angular/core";

@Injectable()
export class AppCommentEffect{
    
    constructor(
        private actions : Actions,
        private store : Store<appCommentState.AppCommentState>,
        private commentService : CommentService
    ) {}

    nextPageOfComments$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(appCommentActions.nextPageOfComments),
            mergeMap(
                action => this.store.select(appCommentSelectors.selectStatusOfComments({queryId : action.queryId})).pipe(
                    first(),
                    mergeMap(status => this.store.select(appCommentSelectors.selectPageOfComments({queryId : action.queryId})).pipe(
                        first(),
                        map(page => ({status : status,page : page,postId : action.postId,queryId : action.queryId})),
                    )),
                )
            ),
            filter(x => !x.status),
            mergeMap(x => this.commentService.getCommnetsByPostId(x.postId,x.page).pipe(
                mergeMap(response => of(appCommentActions.nextPageOfCommentsSuccess({payload : response,queryId : x.queryId})))
            )),
        )
    })
    nextPageOfChildren$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(appCommentActions.nextPageOfChildren),
            mergeMap(
                action => this.store.select(appCommentSelectors.selectStatusOfComments({queryId : action.queryId})).pipe(
                    first(),
                    mergeMap(status => this.store.select(appCommentSelectors.selectPageOfComments({queryId : action.queryId})).pipe(
                        first(),
                        map(page => ({status : status,page : page,commentId : action.commentId,queryId : action.queryId})),
                    )),
                )
            ),
            filter(x => !x.status),
            mergeMap(x => this.commentService.getChildren(x.commentId,x.page).pipe(
                mergeMap(response => of(appCommentActions.nextPageOfCommentsSuccess({payload : response,queryId : x.queryId})))
            )),
        )
    })
} 