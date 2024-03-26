import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { FileService } from "src/app/services/file.service";
import { loadUserImageAction, loadUserImageSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { UserImageEntityState } from "./reducer";
import { selectState } from "./selectors";

@Injectable()
export class UserImageEffect{

  constructor(
    private readonly actions : Actions,
    private readonly imageService : FileService,
    private readonly userImageStore : Store<UserImageEntityState>) {
  }

  loadUserImage$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadUserImageAction),
        mergeMap(
          action => this.userImageStore.select(selectState({id : action.id})).pipe(
            first(),
            filter(state => state == undefined),
            mergeMap(() => this.imageService.downloadFile(action.containerName,action.blobName,action.extention)),
            mergeMap( response => of(loadUserImageSuccessAction({ id : action.id,url : response })))
          )
        )
      )
    }
  )

}
