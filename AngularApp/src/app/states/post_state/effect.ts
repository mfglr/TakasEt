import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { filter, map, mergeMap, of, withLatestFrom } from "rxjs";
import * as appPostActions from "./actions";
import * as appPostSelectors from "./selectors";
import { AppPostState } from "./state";
import { Store } from "@ngrx/store";

@Injectable()
export class AppPostsEffect{
    constructor(
        private actions : Actions,
        private postService : PostService,
        private store : Store<AppPostState>
    ) {}
    nextPageOfPosts$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(appPostActions.nextPageOfPosts),
            withLatestFrom(
                this.store.select(appPostSelectors.selectSelectedQueryId),
                this.store.select(appPostSelectors.selectStatusOfSelectedPosts),
                this.store.select(appPostSelectors.selectPageOfSelectedPosts)
            ),
            filter(([action,queryId,status,page]) => queryId != undefined && status != undefined && !status && page != undefined ),
            mergeMap(([action,queryId,status,page]) => this.postService.getPostsWithFirstImages(page!).pipe(
                mergeMap(response =>of(appPostActions.nextPageOfPostsSuccess({ queryId : queryId!,posts : response})))
            ))
        )
    })
}