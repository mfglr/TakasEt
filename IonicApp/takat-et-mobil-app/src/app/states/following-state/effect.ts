import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserFollowingService } from "src/app/services/user-following.service";
import { commitFollowedValueAction, commitFollowedValueSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { EntityFollowingState } from "./reducer";
import { selectFollowingState } from "./selectors";
import { filterEntityFollowingState } from "src/app/custom-operators/filter-entity-following-state";

@Injectable()
export class EntityFollowingEffect{
  constructor(
    private actions : Actions,
    private followingService : UserFollowingService,
    private entityFollowingStore : Store<EntityFollowingState>
  ) {}

  commitFollowedValue$ = createEffect(() => {
    return this.actions.pipe(
      ofType(commitFollowedValueAction),
      mergeMap(
        action => this.entityFollowingStore.select(selectFollowingState({userId : action.userId})).pipe(
          filterEntityFollowingState(),
          mergeMap(x => {
            if(x.isFollowed)
              return this.followingService.follow(action.userId).pipe(
                mergeMap(() => of(commitFollowedValueSuccessAction({userId : action.userId,value : true})))
              )
            else
              return this.followingService.unfollow(action.userId).pipe(
                mergeMap(() => of(commitFollowedValueSuccessAction({userId : action.userId,value : false})))
              )
          })
        )
      )
    )
  })
}
