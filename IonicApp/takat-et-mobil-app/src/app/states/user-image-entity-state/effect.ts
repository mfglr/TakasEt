import { Injectable } from "@angular/core";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadProfileImageUrlAction, loadProfileImageUrlSuccessAction } from "./actions";
import { UserImageEntityState } from "./reducer";
import { selectState } from "./selectors";
import { UserImageService } from "src/app/services/user-image.service";

@Injectable()
  export class UserImageEntityEffect{

    constructor(
      private actions : Actions,
      private userImageService : UserImageService,
      private profileImageStore : Store<UserImageEntityState>
    ) {}

    loadProfileImage$ = createEffect(() => {
      return this.actions.pipe(
        ofType(loadProfileImageUrlAction),
        mergeMap(
          action => this.profileImageStore.select(selectState({id : action.id})).pipe(
            filter(state => state != undefined),
            first(),
            filter(state => !(state!.loadStatus)),
            mergeMap(() => this.userImageService.getUserImage(action.id)),
            mergeMap(url => of(loadProfileImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    })
}
