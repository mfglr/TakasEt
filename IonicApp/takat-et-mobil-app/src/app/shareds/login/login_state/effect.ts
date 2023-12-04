import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadUser, loadUserSuccess, login, loginByRefreshToken, loginFromLocalStorage, loginSuccess } from "./actions";
import { filter, map, mergeMap, of, withLatestFrom} from "rxjs";
import { Injectable } from "@angular/core";
import { LoginService } from "src/app/services/login.service";
import { Store } from "@ngrx/store";
import { selectUserId } from "./selectors";
import { LoginResponse } from "src/app/models/responses/login-response";
import { UserService } from "src/app/services/user.service";
import { LoginState } from "./reducer";

@Injectable()
export class LoginEffect{
  constructor(
    private actions : Actions,
    private loginService : LoginService,
    private userService : UserService,
    private loginStore : Store<LoginState>
) {}

  login$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(login),
        mergeMap( action => this.loginService.login(action.email,action.password)),
        mergeMap(
          response => of(
            loginSuccess({ payload : response}),
            loadUser({ userId : response.userId }),
          )
        )
      )
    }
  )

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshToken),
      mergeMap( action => this.loginService.loginByRefreshToken(action.refreshToken)),
      mergeMap(response => { return of(
        loginSuccess({ payload : response}),
        loadUser({ userId : response.userId }),
      )})
    )
  })

  loginFromLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginFromLocalStorage),
      map( () : LoginResponse | undefined => {
        const loginResponse = localStorage.getItem("login_response");
        if(loginResponse){
          return JSON.parse(loginResponse)
        }
        return undefined;
      }),
      filter(x => x != undefined),
      mergeMap(response => { return of(
        loginSuccess({ payload : response!}),
        loadUser({ userId : response!.userId })
      )})
    )
  })

  loadUser$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loadUser),
      withLatestFrom(this.loginStore.select(selectUserId)),
      filter(([action,userId]) => !(!userId)),
      mergeMap(([action,userId]) => this.userService.getUser(userId!)),
      mergeMap(response => of(
        loadUserSuccess({payload : response}),
      ))
    )
  })

}
