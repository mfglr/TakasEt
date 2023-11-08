import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadProfileImage, loadProfileImageSuccess, login, loginByRefreshToken, loginFromLocalStorage, loginSuccess } from "./actions";
import { filter, map, mergeMap, of, withLatestFrom} from "rxjs";
import { Injectable } from "@angular/core";
import { LoginService } from "src/app/services/login.service";
import { ProfileImageService } from "src/app/services/profile-image.service";
import { AppLoginState } from "./state";
import { Store } from "@ngrx/store";
import { selectUserId } from "./selectors";

@Injectable()
export class AppLoginEffect{
  constructor(
    private actions : Actions,
    private loginService : LoginService,
    private profileImageService : ProfileImageService,
    private loginStore : Store<AppLoginState>
) {}


  loadProfileImage$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loadProfileImage),
      withLatestFrom(this.loginStore.select(selectUserId)),
      filter(([action,userId]) => !(!userId)),
      mergeMap(([action,userId]) => this.profileImageService.getActiveProfileImage(userId!)),
      mergeMap(profileImage => of(loadProfileImageSuccess({payload : profileImage})))
    )
  })

  login$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(login),
        mergeMap( action => this.loginService.login(action.email,action.password)),
        mergeMap(response => {return of(loginSuccess({ payload : response}))})
      )
    }
  )

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshToken),
      mergeMap( action => this.loginService.loginByRefreshToken(action.refreshToken)),
      mergeMap(response => { return of(loginSuccess({ payload : response}))})
    )
  })

  loginFromLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginFromLocalStorage),
      map( () => {
        let loginResponse = localStorage.getItem("login_response");
        if(loginResponse)
            return JSON.parse(loginResponse)
        return undefined;
      }),
      filter(x => x != undefined),
      mergeMap(response => { return of(loginSuccess({ payload : response}))})
    )
  })

}
