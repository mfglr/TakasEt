import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserService } from "src/app/services/user.service";
import { loadUserAction, loadUserSuccessAction } from "./actions";
import { mergeMap, of } from "rxjs";
import { loadProfileImageSuccessAction } from "../profile-image-state/actions";

@Injectable()
export class UserEffect{

  constructor(
    private actions : Actions,
    private userService : UserService
  ) {}

  loadUser$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loadUserAction),
      mergeMap(action => this.userService.getUser(action.userId)),
      mergeMap(response => of(
        loadUserSuccessAction({ user : response}),
        loadProfileImageSuccessAction({image : response.profileImage})
      ))
    )
  })

}
