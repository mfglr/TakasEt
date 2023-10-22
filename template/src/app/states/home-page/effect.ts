import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter,mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { nextPageOfChildren, nextPageOfChildrenSuccess, nextPageOfComments, nextPageOfCommentsSuccess, nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
import { CommentService } from "src/app/services/comment.service";
import { HomePageState } from "./reducer";
import { selectPageOfCommentsOfSelectedCommentState, selectPageOfCommentsOfSelectedPostState, selectPageOfPosts, selectSelectedCommentId, selectSelectedPostId, selectStatusOfCommentsOfSelectedCommentState, selectStatusOfCommentsOfSelectedPostState, selectStatusOfPosts } from "./selectors";

@Injectable()
export class HomeEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private store : Store<HomePageState>,
    private commentService : CommentService
  ) {}

  nextPageOfPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfPosts),
        withLatestFrom(
          this.store.select(selectStatusOfPosts),
          this.store.select(selectPageOfPosts)
        ),
        filter(([action,isLast,page]) => !isLast),
        mergeMap( ([action,isLast,page]) => this.postService.getPostsWithFirstImages(page)),
        mergeMap(response => of(nextPageOfPostsSuccess({posts : response})))
      )
    }
  )

  nextPageOfComments$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfComments),
        withLatestFrom(
          this.store.select(selectSelectedPostId),
          this.store.select(selectStatusOfCommentsOfSelectedPostState),
          this.store.select(selectPageOfCommentsOfSelectedPostState),
        ),
        filter(([action,postId,isLast,page]) => !(!postId) && !isLast && !(!page)),
        mergeMap(([action,postId,isLast,page] ) => this.commentService.getCommnetsByPostId(postId!,page!)),
        mergeMap(response => of(nextPageOfCommentsSuccess({comments : response})))
      )
    }
  )

  nextPageOfChildren$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfChildren),
        withLatestFrom(
          this.store.select(selectSelectedCommentId),
          this.store.select(selectStatusOfCommentsOfSelectedCommentState),
          this.store.select(selectPageOfCommentsOfSelectedCommentState)
        ),
        filter(([action,commentId,isLast,page]) => !(!commentId) && !isLast && !(!page)),
        mergeMap(([action,commentId,isLast,page]) => this.commentService.getChildren(commentId!,page!)),
        mergeMap(response => of(nextPageOfChildrenSuccess({comments : response})))
      )
    }
  )
}
