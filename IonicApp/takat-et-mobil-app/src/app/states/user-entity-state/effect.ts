import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserService } from "src/app/services/user.service";
import { commitFollowingStatusAction, commitFollowingStatusSuccessAction, followAction, loadUserAction, loadUserSuccessAction } from "./actions";
import { mergeMap, of, withLatestFrom } from "rxjs";
import { loadUserImageSuccessAction } from "../user-image-entity-state/actions";
import { UserEntityState } from "./reducer";
import { Store } from "@ngrx/store";
import { selectUserState } from "./selectors";
import { filterUserState } from "src/app/custom-operators/filter-user-state";
import { UserFollowingService } from "src/app/services/user-following.service";
import { LoginState } from "../login_state/reducer";
import { selectUserId } from "../login_state/selectors";

@Injectable()
export class UserEntityEffect{

  constructor(
    private actions : Actions,
    private userService : UserService,
    private userEntityStore : Store<UserEntityState>,
    private followingService : UserFollowingService,
    private logginStore : Store<LoginState>
  ) {}

  loadUser$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loadUserAction),
      mergeMap(
        action => this.userEntityStore.select(selectUserState({userId : action.userId})).pipe(
          filterUserState(),
          mergeMap(() => this.userService.getUser(action.userId)),
          mergeMap(response => of(
            loadUserSuccessAction({ user : response}),
            loadUserImageSuccessAction({image : response.userImage})
          ))
        )
      )
    )
  })

  commitFollowingStatus$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(commitFollowingStatusAction),
        mergeMap(action =>{
          if(action.value)
            return this.followingService.follow(action.userId).pipe(
              mergeMap(() => of(commitFollowingStatusSuccessAction()))
            )
          return this.followingService.unfollow(action.userId).pipe(
            mergeMap(() => of(commitFollowingStatusSuccessAction()))
          )
        })
      )
    }
  )


}
