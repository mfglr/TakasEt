import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CommentService } from "src/app/services/comment.service";
import { filter, first, map, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { selectPageAndStatus } from "./selectors";
import { nextPageAction, nextPageActionSuccess } from "./actions";
import { AppChildCommentState } from "./state";

@Injectable()
export class AppChildCommentEffect{
    constructor(
        private commentService : CommentService,
        private actions : Actions,
        private store : Store<AppChildCommentState>
    ){}

    nextPage$ = createEffect( () => {
        return this.actions.pipe(
            ofType(nextPageAction),
            mergeMap(
                action => this.store.select(selectPageAndStatus({parentComment : action.parentComment})).pipe(
                    first(),
                    filter(x => !x.status),
                    mergeMap(x => this.commentService.getChildren(x.parentComment.id,x.page).pipe(
                        mergeMap(response => of(nextPageActionSuccess({payload : response,parentComment : x.parentComment})))
                    )),
                )
            ),
        )
    })
}