import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { LoginService } from "../services/login.service";
import { PostService } from "../services/post.service";
import { UserService } from "../services/user.service";
import { loadPostImageUrlAction, loadPostImageUrlSuccessAction, loadPostImagesSuccessAction, loadUserAction, loadUserImageSuccessAction, loadUserImageUrlAction, loadUserImageUrlSuccessAction, loadUserSuccessAction, loginAction, loginByRefreshTokenAction, loginFailedAction, loginFromLocalStorageAction, loginSuccessAction, nextPostsAction, nextPostsSuccessAction } from "./actions";
import { filter, map, mergeMap, of, withLatestFrom } from "rxjs";
import { selectPostImageLoadStatus, selectPosts, selectUserId, selectUserImageLoadStatus } from "./selector";
import { AppState } from "./reducer";
import { Store } from "@ngrx/store";
import { LoginResponse } from "../models/responses/login-response";

@Injectable()
export class AppEffect{

  constructor(
    private actions : Actions,
    private appStore : Store<AppState>,
    private loginService : LoginService,
    private postService : PostService,
    private userService : UserService
  ) {}


  loadUser$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadUserAction),
        withLatestFrom(this.appStore.select(selectUserId)),
        filter(([action,userId]) => userId != undefined),
        mergeMap(([action,userId]) => this.userService.getUser(userId!)),
        mergeMap(response => of(
          loadUserSuccessAction({payload : response}),
          loadUserImageSuccessAction({userImageId : response.userImage?.id})
        ))
      )
    }
  )

  loging$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loginAction),
        mergeMap(action => this.loginService.login(action.email,action.password)),
        mergeMap(response => of(loginSuccessAction({payload : response})))
      )
    }
  )

  loginByRefreshToken$ = createEffect(() => {
    return this.actions.pipe(
      ofType(loginByRefreshTokenAction),
      mergeMap( action => this.loginService.loginByRefreshToken(action.refreshToken)),
      mergeMap(response => of(
        loginSuccessAction({ payload : response}),
      ))
    )
  })

  loginFromLocalStorage$ = createEffect( () => {
    return this.actions.pipe(
      ofType(loginFromLocalStorageAction),
      map( () : LoginResponse | undefined => {
        const loginResponse = localStorage.getItem("login_response");
        if(loginResponse){ return JSON.parse(loginResponse) }
        return undefined;
      }),
      mergeMap(
        response => {
          if(response){
            if(new Date(response.expirationDateOfAccessToken).getTime() > Date.now()){
              return of( loginSuccessAction({ payload : response}) )
            }
            else{
              if(new Date(response.expirationDateOfRefreshToken).getTime() > Date.now()){
                return of(loginByRefreshTokenAction({refreshToken : response.refreshToken}))
              }
              else{
                return of(loginFailedAction())
              }
            }
          }
          else{
            return of(loginFailedAction())
          }
        }
      )
    )
  })

  nextPosts$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPostsAction),
        withLatestFrom(
          this.appStore.select(selectPosts),
          this.appStore.select(selectUserId)
        ),
        filter( ([action,state,userId]) => !state.isLastEntities && userId != undefined ),
        mergeMap( ([action,state,userId]) => this.postService.getUserPosts(userId!,state.page) ),
        mergeMap(response => of(
          nextPostsSuccessAction({payload : response}),
          loadPostImagesSuccessAction({
            postImageIds :
              response.length > 0 ?
                response.map(x => x.postImages.map(x => x.id)).reduce((prev,cur) => cur.concat(prev)) :
                []
          })

        ))
      )
    }
  )

  loadPostImageUrl$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType( loadPostImageUrlAction ),
        mergeMap(
          action => this.appStore.select(selectPostImageLoadStatus({id : action.id})).pipe(
            filter(loadStatus => loadStatus!= undefined && !loadStatus),
            mergeMap(() => this.postService.getPostImage(action.id)),
            mergeMap(url => of(loadPostImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    }
  )

  loadUserImageUrl$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType( loadUserImageUrlAction ),
        mergeMap(
          action => this.appStore.select(selectUserImageLoadStatus({id : action.id})).pipe(
            filter(loadStatus => loadStatus!= undefined && !loadStatus),
            mergeMap(() => this.userService.getUserImage(action.id)),
            mergeMap(url => of(loadUserImageUrlSuccessAction({id : action.id,url : url})))
          )
        )
      )
    }
  )

}
