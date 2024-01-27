import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { FilterPostsPageState } from "./reducer";
import { Store } from "@ngrx/store";
import { filterPostsByCategoryIdsAction, filterPostsByCategoryIdsSuccessAction, filterPostsByKeyAction, filterPostsByKeySuccessAction,nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectCategoryIds, selectKey, selectPosts } from "./selectors";
import { takeValueOfPosts } from "src/app/state/app-entity-state/app-entity-state";

@Injectable()
export class FilterPostsPageEffect{
  constructor(
    private actions : Actions,
    private postService : PostService,
    private filterPageStore : Store<FilterPostsPageState>
  ) {}

  // filterPostsByKey$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(filterPostsByKeyAction),
  //       withLatestFrom(
  //         this.filterPageStore.select(selectCategoryIds),
  //       ),
  //       mergeMap(
  //         ([action,categoryIds]) => this.postService.getFilterPagePosts(
  //           categoryIds,action.key,{lastId : undefined,take : takeValueOfPosts}
  //         ).pipe(
  //           mergeMap(response => of(
  //             filterPostsByKeySuccessAction({key : action.key,payload : response}),
  //             loadPostsAction({posts : response})
  //           ))
  //         )
  //       ),
  //     )
  //   }
  // )

  // filterPostsByCategoryIds$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(filterPostsByCategoryIdsAction),
  //       withLatestFrom(
  //         this.filterPageStore.select(selectKey),
  //       ),
  //       mergeMap(
  //         ([action,key]) => this.postService.getFilterPagePosts(
  //           action.categoryIds,key,{lastId : undefined,take : takeValueOfPosts}
  //         ).pipe(
  //           mergeMap(response => of(
  //             filterPostsByCategoryIdsSuccessAction({categoryIds : action.categoryIds,payload : response}),
  //             loadPostsAction({posts : response})
  //           ))
  //         )
  //       ),
  //     )
  //   }
  // )

  // nextPosts$ = createEffect(
  //   () => {
  //     return this.actions.pipe(
  //       ofType(nextPostsAction),
  //       withLatestFrom(
  //         this.filterPageStore.select(selectCategoryIds),
  //         this.filterPageStore.select(selectKey),
  //         this.filterPageStore.select(selectPosts)
  //       ),
  //       filter(([action,categoryIds,key,state]) => !state.isLastEntities),
  //       mergeMap( ([action,categoryIds,key,state]) => this.postService.getFilterPagePosts(categoryIds,key,state.page) ),
  //       mergeMap(response => of(
  //         nextPostsSuccessAction({payload : response}),
  //         loadPostsAction({posts : response})
  //       ))
  //     )
  //   }
  // )
}
