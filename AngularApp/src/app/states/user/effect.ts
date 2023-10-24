import { Actions, createEffect, ofType } from "@ngrx/effects";
import { login, loginByRefreshToken, loginFailedFromLocalStorage, loginFromLocalStorage, loginSuccess } from "./actions";
import { mergeMap, of} from "rxjs";
import { Injectable } from "@angular/core";
import { LoginService } from "src/app/services/login.service";

@Injectable()
export class UserEffect{
  constructor(
    private actions : Actions,
    private loginService : LoginService) {

  }

  login$ = createEffect(() => {
    return this.actions.pipe(
      ofType(login),
      mergeMap( action => this.loginService.login(action.email,action.password) ),
      mergeMap(
        response => {
          return of(
            loginSuccess({ payload : response}),
          )
        }
      )
    )
  })

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshToken),
      mergeMap( action => this.loginService.loginByRefreshToken(action.refreshToken) ),
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
