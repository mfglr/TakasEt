import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AppFileService } from "src/app/services/app-file.service";
import { loadPostImageUrlAction, loadPostImageUrlSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { State } from "./reducer";
import { selectPostImageState } from "./selectors";
import { Injectable } from "@angular/core";

@Injectable()
export class PostImageEffect{
  constructor(
    private actions : Actions,
    private appFileService : AppFileService,
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
            mergeMap(state => this.appFileService.getAppFile(action.id)),
            mergeMap(url => of(loadPostImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    }
  )
}
