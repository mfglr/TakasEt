import { Actions, createEffect, ofType } from "@ngrx/effects";
import { login, loginFailedFromLocalStorage, loginFromLocalStorage, loginSuccess } from "./actions";
import { UserService } from "src/app/services/user.service";
import { map, mergeMap, of} from "rxjs";
import { Injectable } from "@angular/core";

@Injectable()
export class UserEffect{
  constructor(private actions : Actions,private userService : UserService) {

  }

  login$ = createEffect(() => {
    return this.actions.pipe(
      ofType(login),
      mergeMap( action => this.userService.login(action.email,action.password) ),
      mergeMap(
        response => {
          return of(
            loginSuccess({ payload : response}),
          )
        }
      )
    )
  })

  loginFromLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginFromLocalStorage),
      mergeMap( () => {
        var loginResponse = localStorage.getItem("loginResponse");
        if(loginResponse) return of( loginSuccess({payload : JSON.parse(loginResponse)}) )
        else return of( loginFailedFromLocalStorage() )
      })
    )
  })

}
