import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter,mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { nextPageOfChildren, nextPageOfChildrenSuccess, nextPageOfComments, nextPageOfCommentsSuccess, nextPageOfPostLikers, nextPageOfPostLikersSuccess, nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
import { CommentService } from "src/app/services/comment.service";
import { HomePageState } from "./reducer";
import { UserService } from "src/app/services/user.service";
import { selectPageOfHomePagePosts, selectSelectedCommentId, selectSelectedPostId, selectStatusOfHomePagePosts } from "./selectors/home-page-selectors";
import { selectPageOfChildren, selectPageOfComments, selectStatusOfChildren, selectStatusOfComments } from "./selectors/comments-selectors";
import { selectPageOfLikers, selectStatusOfLikers } from "./selectors/likers-selectors";

@Injectable()
export class HomeEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private store : Store<HomePageState>,
    private commentService : CommentService,
    private userService : UserService
  ) {}

  nextPageOfPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfPosts),
        withLatestFrom(
          this.store.select(selectStatusOfHomePagePosts),
          this.store.select(selectPageOfHomePagePosts)
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
          this.store.select(selectStatusOfComments),
          this.store.select(selectPageOfComments),
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
          this.store.select(selectStatusOfChildren),
          this.store.select(selectPageOfChildren)
        ),
        filter(([action,commentId,isLast,page]) => !(!commentId) && !isLast && !(!page)),
        mergeMap(([action,commentId,isLast,page]) => this.commentService.getChildren(commentId!,page!)),
        mergeMap(response => of(nextPageOfChildrenSuccess({comments : response})))
      )
    }
  )

  nextPageOfPostLikers$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfPostLikers),
        withLatestFrom(
          this.store.select(selectSelectedPostId),
          this.store.select(selectStatusOfLikers),
          this.store.select(selectPageOfLikers)
        ),
        filter(([action,postId,isLast,page]) => !(!postId) && !isLast && !(!page)),
        mergeMap(([action,postId,isLast,page]) => this.userService.getUsersWhoLikedPost(postId!,page!)),
        mergeMap(response => of(nextPageOfPostLikersSuccess({likers : response})))
      )
    }
  )
}
