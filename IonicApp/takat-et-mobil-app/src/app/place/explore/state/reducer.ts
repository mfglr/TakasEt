import { createReducer, on } from "@ngrx/store";
import { Page, takeValueOfPosts } from "src/app/states/app-states";
import { initPageState, nextPageSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

interface ExplorePageState{
  postIds : number[];
  page : Page;
  status : boolean;
  initialPost : PostResponse;
}
export interface State extends EntityState<ExplorePageState>{}

const adapter = createEntityAdapter<ExplorePageState>({selectId : x => x.initialPost.id})


export const explorePageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initPageState,
    (state,action) => adapter.addOne({
      initialPost : action.post,
      page : {
        lastId : action.post.id,
        skip : 0,
        take : takeValueOfPosts
      },
      postIds : [],
      status : false
    },state)
  ),
  on(
    nextPageSuccessAction,
    (state,action) => adapter.updateOne(
      {
        id : action.postId,
        changes : {
          postIds : [...state.entities[action.postId]!.postIds,...action.payload.map(x => x.id)],
          status : action.payload.length < takeValueOfPosts,
          page : {
            ...state.entities[action.postId]!.page,
            skip : state.entities[action.postId]!.page.skip + takeValueOfPosts,
            lastId : action.payload.length ? action.payload[action.payload.length - 1].id : undefined
          }
        }
      },
      state
    )
  )
)
