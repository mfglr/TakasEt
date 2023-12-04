import { Injectable } from "@angular/core";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AppFileService } from "src/app/services/app-file.service";
import { loadProfileImageAction, loadProfileImageSuccessAction } from "./actions";
import { ProfileImageState } from "./reducer";
import { selectLoadStatus } from "./selectors";

@Injectable()
export class ProfileImageEffect{
    
    constructor(
        private actions : Actions,
        private appFileService : AppFileService,
        private profileImageStore : Store<ProfileImageState>
    ) {}
    
    loadProfileImage$ = createEffect(() => {
        return this.actions.pipe(
            ofType(loadProfileImageAction),
            mergeMap(
                action => this.profileImageStore.select(selectLoadStatus({id : action.id})).pipe(
                    first(),
                    filter(x => x != true),
                    mergeMap(
                        () => this.appFileService.getAppFile(action.id).pipe(
                            mergeMap(url => of(loadProfileImageSuccessAction({id : action.id,url : url})))
                        )
                    )
                )
            )
        )
    })
}