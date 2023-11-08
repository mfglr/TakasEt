import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CommentService } from "src/app/services/comment.service";
import { filter, first, map, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { Injectable } from "@angular/core";
import { selectPageAndStatus } from "./selectors";
import { AppCommentState } from "./state";
import { addAction, addSuccessAction, nextPageAction, nextPageSuccessAction } from "./actions";

@Injectable()
export class AppCommentEffect{
    
    constructor(
        private actions : Actions,
        private store : Store<AppCommentState>,
        private commentService : CommentService
    ) {}

    add$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(addAction),
            mergeMap(action => this.commentService.addComment(action.request)),
            mergeMap(response => of(addSuccessAction({payload : response})))
        )
    })
    nextPage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageAction),
            mergeMap(
                action => this.store.select(selectPageAndStatus({postId : action.postId})).pipe(
                    first(),
                    filter(x => !x.status),
                    mergeMap(x => this.commentService.getCommnetsByPostId(x.postId,x.page).pipe(
                        mergeMap(response => of(nextPageSuccessAction({payload : response,postId : x.postId})))
                    )),
                )
            ),
        )
    })
}   