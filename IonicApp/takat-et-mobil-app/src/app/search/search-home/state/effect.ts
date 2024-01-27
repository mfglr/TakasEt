import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PostService } from "src/app/services/post.service";
import { nextUsersAction, nextUsersSuccessAction, searchUsersAction, searchUsersSuccessAction } from "./action";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";
import { selectKey, selectPosts, selectUsers } from "./selector";
import { takeValueOfPosts } from "src/app/state/app-entity-state/app-entity-state";
import { UserService } from "src/app/services/user.service";

@Injectable()
export class SearchHomePageEffect{

  constructor(
    private actions : Actions,
    private postService : PostService,
    private userService : UserService,
    private searchHomePageStore : Store<SearchHomePageState>
  ) {}

  // searchUsers$ = createEffect( () => {
  //   return this.actions.pipe(
  //     ofType(searchUsersAction),
  //     mergeMap(
  //       action => this.userService.getSearchPageUsers(action.key,{lastId : undefined,take : takeValueOfPosts}).pipe(
  //         mergeMap(
  //           response => of(
  //             searchUsersSuccessAction({key : action.key,users : response}),
  //             loadUsersAction({users : response})
  //           )
  //         )
  //       )
  //     )
  //   )
  // })

  // nextPosts$ = createEffect(() => {
  //   return this.actions.pipe(
  //     ofType(nextPostsAction),
  //     withLatestFrom(
  //       this.searchHomePageStore.select(selectPosts)
  //     ),
  //     filter(([action,state]) => !state.isLastEntities),
  //     mergeMap(([action,state]) => this.postService.getSearchPagePosts(state.page)),
  //     mergeMap(response => of(
  //       nextPostsSuccessAction({posts : response}),
  //       loadPostsAction({posts : response})
  //     ))
  //   )
  // })

  // nextUsers$ = createEffect( () => {
  //   return this.actions.pipe(
  //     ofType(nextUsersAction),
  //     withLatestFrom(
  //       this.searchHomePageStore.select(selectUsers),
  //       this.searchHomePageStore.select(selectKey)
  //     ),
  //     filter(([action,state,key]) => !state.isLastEntities),
  //     mergeMap(([action,state,key]) => this.userService.getSearchPageUsers(key,state.page)),
  //     mergeMap(response => of(
  //       nextUsersSuccessAction({users : response}),
  //       loadUsersAction({users : response})
  //     ))
  //   )
  // })

}
