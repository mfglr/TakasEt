import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { PostService } from "src/app/services/post.service";
import { nextPageOfComments, nextPageOfCommentsSuccess, nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
import { selectCurrentPageOfComments, selectCurrentPageOfPosts, selectSelectedPostId, selectStatusOfComments, selectStatusOfPosts } from "./selectors";
import { HomeState } from "./states";
import { CommentService } from "src/app/services/comment.service";

@Injectable()
export class HomeEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private store : Store<HomeState>,
    private commentService : CommentService
  ) {}

  nextPageOfPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfPosts),
        withLatestFrom(this.store.select(selectStatusOfPosts)),
        filter(([action,status]) => !status),
        withLatestFrom(this.store.select(selectCurrentPageOfPosts)),
        mergeMap( ([[action,status],page]) => this.postService.getPostsWithFirstImages(page)),
        mergeMap(response => of(nextPageOfPostsSuccess({posts : response})))
      )
    }
  )

  nextPageOfComments$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageOfComments),
        withLatestFrom(this.store.select(selectSelectedPostId)),
        filter(([action,postId]) => !(!postId)),
        withLatestFrom(this.store.select(selectStatusOfComments)),
        filter(([[action,postId],isLast]) => !isLast),
        withLatestFrom(this.store.select(selectCurrentPageOfComments)),
        filter(([[[action,postId],isLast],page]) => !(!page)),
        mergeMap(([[[action,postId],isLast],page]) => this.commentService.getCommnetsByPostId(postId!,page!)),
        mergeMap(response => of(nextPageOfCommentsSuccess({comments : response})))
      )
    }
  )

  // nextPageOfChildren$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       withLatestFrom(this.store.select(selectSelectedPostId)),
  //       filter(([action,postId]) => !(!postId)),
  //       withLatestFrom(this.store.select())
  //     )
  //   }
  // )
}
