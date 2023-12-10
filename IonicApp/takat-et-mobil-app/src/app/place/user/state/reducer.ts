import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { Page, takeValueOfPosts } from "src/app/states/app-states";
import { changeActiveTabAction, initUserPageStateAction, nextPageOfPostsSuccessAction } from "./actions";

interface PostState{
  postIds : number[];
  page : Page;
  status : boolean;
}

interface UserPageState{
  userId : number;
  posts : PostState;
  activeTab : number;
}
export interface State extends EntityState<UserPageState>{}

const adapter = createEntityAdapter<UserPageState>({
  selectId : x => x.userId
})


export const userPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    changeActiveTabAction,
    (state,action) => adapter.updateOne({ id : action.userId, changes : { activeTab : action.activeTab } },state)
  ),
  on(
    initUserPageStateAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      activeTab : 0,
      posts : {
        page : { lastId : undefined, skip : 0, take : takeValueOfPosts },
        postIds : [],
        status : false
      }
    },state)
  ),
  on(
    nextPageOfPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        posts : {
          page : {
            ...state.entities[action.userId]!.posts.page,
            skip : state.entities[action.userId]!.posts.page.skip + takeValueOfPosts,
            lastId : action.payload.length ? action.payload[action.payload.length - 1].id : undefined
          },
          postIds : [...state.entities[action.userId]!.posts.postIds,...action.payload.map(x => x.id)],
          status : action.payload.length < takeValueOfPosts,
        }
      }
    },state)
  )
)
