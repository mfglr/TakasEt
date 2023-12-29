import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction, searchPostsAction, searchPostsSuccessAction } from "./action";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";
import { selectKey, selectPosts } from "./selector";
import { takeValueOfPosts } from "src/app/states/app-entity-state";
import { loadPostsAction } from "src/app/states/actions";

@Injectable()
export class SearchHomePageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private searchHomePageStore : Store<SearchHomePageState>
  ) {}

  searchPosts$ = createEffect( () => {
    return this.actions.pipe(
      ofType(searchPostsAction),
      mergeMap(
        action => this.postService.getSearchPagePosts(action.key,{lastId : undefined,take : takeValueOfPosts}).pipe(
          mergeMap(
            response => of(
              searchPostsSuccessAction({key : action.key,posts : response}),
              loadPostsAction({posts : response})
            )
          )
        )
      )
    )
  })

  nextPosts$ = createEffect(() => {
    return this.actions.pipe(
      ofType(nextPostsAction),
      withLatestFrom(
        this.searchHomePageStore.select(selectPosts),
        this.searchHomePageStore.select(selectKey)
      ),
      filter(([action,state,key]) => !state.isLastEntities),
      mergeMap(([action,state,key]) => this.postService.getSearchPagePosts(key,state.page)),
      mergeMap(response => of(
        nextPostsSuccessAction({posts : response}),
        loadPostsAction({posts : response})
      ))
    )
  })



}
