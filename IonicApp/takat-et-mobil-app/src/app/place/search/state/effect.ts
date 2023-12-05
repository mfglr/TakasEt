import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPageAction, nextPageSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom} from "rxjs";
import { Store } from "@ngrx/store";
import { selectStatusAndPage } from "./selectors";
import { Injectable } from "@angular/core";
import { SearchPageState } from "./reducer";
import { addPostsAction } from "src/app/states/post-state/actions";

@Injectable()
export class SearchPageEffect{

    constructor(
        private actions : Actions,
        private postService : PostService,
        private searchPageStore : Store<SearchPageState>,
    ) {}

    nextPage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageAction),
            withLatestFrom(this.searchPageStore.select(selectStatusAndPage)),
            filter(([action,x]) => !x.status),
            mergeMap(([action,x]) => this.postService.getSearchPosts(x.page)),
            mergeMap(
                response => of(
                    nextPageSuccessAction({payload : response}),
                    addPostsAction({payload : response})
                )
            )
        )
    })
   
}