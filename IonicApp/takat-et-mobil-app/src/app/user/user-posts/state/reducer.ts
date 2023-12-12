import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { Page, takeValueOfPosts } from "src/app/states/app-states";
import { initUserPostsPageStateAction, nextPageSuccessAction } from "./actions";

interface PageState{
  userId : number;
  postIds : number[];
  page : Page;
  status : boolean;
}
export interface UserPostsPageState extends EntityState<PageState>{}
const adapter = createEntityAdapter<PageState>({ selectId: x => x.userId })


export const userPostsPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initUserPostsPageStateAction,
    (state,action) => adapter.addOne({
      page : action.page,
      postIds : action.postIds,
      status : action.status,
      userId : action.userId
    },state)
  ),
  on(
    nextPageSuccessAction,
    (state,action) => adapter.updateOne(
      {
        id : action.userId,
        changes : {
          page : {
            ...state.entities[action.userId]!.page,
            skip : state.entities[action.userId]!.page.skip + takeValueOfPosts,
            lastId : action.posts.length ? action.posts[action.posts.length - 1].id : undefined
          },
          postIds : [...state.entities[action.userId]!.postIds,...action.posts.map(x => x.id)],
          status : action.posts.length < takeValueOfPosts,
        }
      },
      state
    )
  )
)
