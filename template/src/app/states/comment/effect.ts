import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CommentService } from "src/app/services/comment.service";
import * as CommentActions from './actions';
import { mergeMap, of } from "rxjs";

@Injectable()
export class CommentEffect{
  constructor(
    private actions : Actions,
    private commentService : CommentService
  ) {}

  getCommetsByPostId$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(CommentActions.getCommentsByPostId),
        mergeMap((action) => this.commentService.getCommnetsByPostId(action.postId)),
        mergeMap(response => of(CommentActions.getCommentsByPostIdSuccess({ comments : response })))
      )
    }
  )

  getChildren$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(CommentActions.getCommentWithChildren),
        mergeMap((action) => this.commentService.getCommnetWithChildren(action.parentId)),
        mergeMap(response => of(CommentActions.getCommentWithChildrenSuccess({payload : response})))
      )
    }
  )

  addComment$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(CommentActions.addComment),
        mergeMap((action) => this.commentService.addComment(action.comment)),
        mergeMap(response => of(CommentActions.addCommentSuccess({comment : response})))
      )
    }
  )

}
