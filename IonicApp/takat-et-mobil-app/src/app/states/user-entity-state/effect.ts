import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserService } from "src/app/services/user.service";
import { loadUserAction, loadUserSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { loadProfileImageSuccessAction } from "../profile-image-state/actions";
import { UserEntityState } from "./reducer";
import { Store } from "@ngrx/store";
import { selectUserState } from "./selectors";
import { filterUserState } from "src/app/custom-operators/filter-user-state";

@Injectable()
export class UserEntityEffect{

  constructor(
    private actions : Actions,
    private userService : UserService,
    private userEntityStore : Store<UserEntityState>
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
            loadProfileImageSuccessAction({image : response.profileImage})
          ))
        )
      )
    )
  })

}
