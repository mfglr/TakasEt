import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadPostImageUrlAction, loadPostImageUrlSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { State } from "./reducer";
import { selectPostImageState } from "./selectors";
import { Injectable } from "@angular/core";
import { PostImageService } from "src/app/services/post-image.service";

@Injectable()
export class PostImageEffect{
  constructor(
    private actions : Actions,
    private postImageService : PostImageService,
    private postImageStore : Store<State>
  ) {}

  loadPostImageUrl$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadPostImageUrlAction),
        mergeMap(
          action => this.postImageStore.select(selectPostImageState({id : action.id})).pipe(
            filter(state => state != undefined),
            first(),
            filter(state => !(state!.loadStatus)),
            mergeMap(state => this.postImageService.getPostImage(action.id)),
            mergeMap(url => of(loadPostImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    }
  )
}
