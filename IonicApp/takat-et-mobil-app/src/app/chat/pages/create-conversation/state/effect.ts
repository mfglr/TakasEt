import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { UserService } from "src/app/services/user.service";
import { CreateConversationPageState } from "./reducer";
import { nextPageUsersAction, nextPageUsersSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectUsers } from "./selectors";

@Injectable()
export class CreateConversationPageEffect{

  constructor(
    private readonly actions : Actions,
    private readonly userService : UserService,
    private readonly createConversationPageStore : Store<CreateConversationPageState>
  ) {}

  nextPageUsers$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageUsersAction),
        withLatestFrom(this.createConversationPageStore.select(selectUsers)),
        filter(([action,state]) => !state.isLastEntities),
        mergeMap(([action,state]) => this.userService.getFollowersOrFollowings(state.page)),
        mergeMap(
          response => {
            if(!response.isError)
              return of(nextPageUsersSuccessAction({payload : response.data!}))
            return of()
          }
        )
      )
    }
  )

}
