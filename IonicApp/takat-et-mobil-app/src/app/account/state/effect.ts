import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { mergeMap, of } from "rxjs";
import { loginAction, loginByLocalStorageAction, loginByRefreshTokenAction, loginCompletedAction, loginFailedAction } from "./actions";
import { LoginService } from "../services/login.service";
import { LoginResponse } from "../models/login-response";


@Injectable()
export class LoginEffect{

  private static readonly timeOffset : number = 3000;
  constructor(private actions : Actions,private loginService : LoginService) {}

  loging$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loginAction),
        mergeMap(action => this.loginService.login(action.email,action.password)),
        mergeMap(
          response =>{
            if(!response.isError)
              return of(loginCompletedAction({payload : response.data!}))
            else
              return of()
          }
        )
      )
    }
  )

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshTokenAction),
      mergeMap( action => this.loginService.loginByRefreshToken(action.userId, action.refreshToken)),
      mergeMap(
        response =>{
          if(!response.isError)
            return of(loginCompletedAction({payload : response.data!}))
          else
            return of()
        }
      )
    )
  })

  loginByLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginByLocalStorageAction),
      mergeMap(
        () => {
          var json = localStorage.getItem("login_response");
          if(!json) return of(loginFailedAction())
          let response : LoginResponse = JSON.parse(json);
          if(new Date(response.expirationDateOfRefreshToken).getTime() > (Date.now() - LoginEffect.timeOffset))
            return of(loginByRefreshTokenAction({userId : response.userId,refreshToken : response.refreshToken}))
          return of(loginFailedAction())
        }
      )
    )
  })

}
