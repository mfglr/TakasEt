import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { UserService } from "src/app/services/user.service";
import { AppState } from "src/app/state/reducer";
import { CreateMessagePageState } from "./reducer";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { nextPageUsersAction, nextPageUsersSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectUserId } from "src/app/state/selector";
import { selectUsers } from "./selectors";
import { loadUserImagesByUserResponsesSuccessAction } from "src/app/state/actions";

@Injectable()
export class CreateMessagePageEffect{
  constructor(
    private actions : Actions,
    private appStore : Store<AppState>,
    private userService : UserService,
    private createMessagePageStore : Store<CreateMessagePageState>
  ) {}

  nextPageUsers$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageUsersAction),
        withLatestFrom(
          this.appStore.select(selectUserId),
          this.createMessagePageStore.select(selectUsers)
        ),
        filter( ([action,userId,state]) => !state.isLastEntities && userId != undefined ),
        mergeMap( ([action,userId,state]) => this.userService.getFollowers(userId!,state.page) ),
        mergeMap( response => of(
          nextPageUsersSuccessAction({payload : response}),
          loadUserImagesByUserResponsesSuccessAction({payload : response})
        ))
      )
    }
  )
}
