import { Injectable } from "@angular/core";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AppFileService } from "src/app/services/app-file.service";
import { loadProfileImageUrlAction, loadProfileImageUrlSuccessAction } from "./actions";
import { ProfileImageState } from "./reducer";
import { selectState } from "./selectors";

@Injectable()
export class ProfileImageEffect{

    constructor(
      private actions : Actions,
      private appFileService : AppFileService,
      private profileImageStore : Store<ProfileImageState>
    ) {}

    loadProfileImage$ = createEffect(() => {
      return this.actions.pipe(
        ofType(loadProfileImageUrlAction),
        mergeMap(
          action => this.profileImageStore.select(selectState({id : action.id})).pipe(
            filter(state => state != undefined),
            first(),
            filter(state => !(state!.loadStatus)),
            mergeMap(() => this.appFileService.getAppFile(action.id)),
            mergeMap(url => of(loadProfileImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    })
}
