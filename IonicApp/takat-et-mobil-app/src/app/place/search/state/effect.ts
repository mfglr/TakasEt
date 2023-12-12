import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom} from "rxjs";
import { Store } from "@ngrx/store";
import { selectStatusAndPage } from "./selectors";
import { Injectable } from "@angular/core";
import { SearchPageState } from "./reducer";
import { loadPostsSuccessAction } from "src/app/states/post-state/actions";
import { loadPostImagesSuccessAction } from "src/app/states/post-image-state/actions";
import { loadProfileImagesSuccessAction } from "src/app/states/profile-image-state/actions";

@Injectable()
export class SearchPageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private searchPageStore : Store<SearchPageState>,
  ) {}

  nextPage$ = createEffect(() =>{
    return this.actions.pipe(
      ofType(nextPostsAction),
      withLatestFrom(this.searchPageStore.select(selectStatusAndPage)),
      filter(([action,x]) => !x.status),
      mergeMap(([action,x]) => this.postService.getSearchPosts(x.page)),
      mergeMap(
        response => of(
          nextPostsSuccessAction({payload : response}),
          loadPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({postImages : response.map(x => x.postImages).reduce((a,c) => a.concat(c))}),
          loadProfileImagesSuccessAction({images : response.map(x => x.profileImage)})
        )
      )
    )
  })

}
