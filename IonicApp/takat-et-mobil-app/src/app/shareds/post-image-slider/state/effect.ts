import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadPostImageAction, loadPostImageSuccessAction } from "./actions";
import { filter, first, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { selectPostImageState } from "./selectors";
import { AppFileService } from "src/app/services/app-file.service";
import { PostImageSliderState } from "./reducer";

@Injectable()
export class PostImageSliderEffect{
    constructor(
        private actions : Actions,
        private sliderStore : Store<PostImageSliderState>,
        private appFileService : AppFileService
    ) {}

    loadPostImage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(loadPostImageAction),
            mergeMap(
                action => this.sliderStore.select(
                    selectPostImageState({postId : action.postId,index : action.index})
                ).pipe(
                    filter(x => x != undefined),
                    first(),
                    filter(x => !(x!.loadStatus)),
                    mergeMap(x => this.appFileService.getAppFile(x!.id)),
                    mergeMap(url => of(loadPostImageSuccessAction({postId : action.postId,index : action.index,url : url})))
                )
            )
        )
    })
}