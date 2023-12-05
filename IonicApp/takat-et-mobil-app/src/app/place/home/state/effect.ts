import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextPageAction, nextPageSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom} from "rxjs";
import { Store } from "@ngrx/store";
import { selectStatusAndPage } from "./selectors";
import { Injectable } from "@angular/core";
import { HomePageState } from "./reducer";
import { addPostsAction } from "src/app/states/post-state/actions";
import { addProfileImagesAction } from "src/app/states/profile-image-state/actions";
import { addPostImagesAction } from "src/app/states/post-image-state/actions";

@Injectable()
export class HomePageEffect{

    constructor(
        private actions : Actions,
        private postService : PostService,
        private homePageStore : Store<HomePageState>,
    ) {}

    nextPage$ = createEffect(() =>{
        return this.actions.pipe(
            ofType(nextPageAction),
            withLatestFrom(this.homePageStore.select(selectStatusAndPage)),
            filter(([action,x]) => !x.status),
            mergeMap(([action,x]) => this.postService.getHomePosts(x.page)),
            mergeMap(
                response => of(
                    nextPageSuccessAction({payload : response}),
                    addPostsAction({payload : response}),
                    addPostImagesAction({postImages : response.map(x => x.postImages).reduce((a,c)=>a.concat(c))}),
                    addProfileImagesAction({images : response.map(x => x.profileImage)})
                )
            )
        )
    })
   
}