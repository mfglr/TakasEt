import { Actions, createEffect, ofType } from "@ngrx/effects";
import { login, loginByRefreshToken, loginFromLocalStorage, loginSuccess } from "./actions";
import { filter, map, mergeMap, of, withLatestFrom} from "rxjs";
import { Injectable } from "@angular/core";
import { LoginService } from "src/app/services/login.service";
import { LoginResponse } from "src/app/models/responses/login-response";
import { loadUserAction } from "../user-entity-state/actions";

@Injectable()
export class LoginEffect{
  constructor(
    private actions : Actions,
    private loginService : LoginService,
) {}

  login$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(login),
        mergeMap(action => this.loginService.login(action.email,action.password)),
        mergeMap(response => of(
          loginSuccess({ payload : response}),
          loadUserAction({userId : response.userId})
        ))
      )
    }
  )

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshToken),
      mergeMap( action => this.loginService.loginByRefreshToken(action.refreshToken)),
      mergeMap(response => of(
        loginSuccess({ payload : response}),
        loadUserAction({userId : response.userId})
      ))
    )
  })

  loginFromLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginFromLocalStorage),
      map( () : LoginResponse | undefined => {
        const loginResponse = localStorage.getItem("login_response");
        if(loginResponse){ return JSON.parse(loginResponse) }
        return undefined;
      }),
      filter(x => x != undefined),
      mergeMap(response => of(
        loginSuccess({ payload : response!}),
        loadUserAction({userId : response!.userId})
      ))
    )
  })

}
