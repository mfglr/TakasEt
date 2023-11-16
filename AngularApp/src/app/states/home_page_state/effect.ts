import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { HomePageState } from "./reducer";
import { selectPageOfPosts, selectStatusOfPosts } from "./selectors";
import { nextPageOfPosts, nextPageOfPostsSuccess } from "./actions";
import { initCommentModalStatesAction } from "../comment_modal_state/action";

@Injectable()
export class HomePageEffect{
    constructor(
        private actions : Actions,
        private postService : PostService,
        private store : Store<HomePageState>
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
}