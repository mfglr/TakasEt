import { createReducer, on } from "@ngrx/store";
import { initPageState, nextPostsSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";
import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { AppEntityState, addMany, init, takeValueOfPosts } from "src/app/states/app-entity-state";

interface ExplorePageState{
  posts : AppEntityState;
  initialPost : PostResponse;
}
export interface State extends EntityState<ExplorePageState>{}

const adapter = createEntityAdapter<ExplorePageState>({selectId : x => x.initialPost.id})

export const explorePageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initPageState,
    (state,action) => adapter.addOne({ initialPost : action.post, posts : init(takeValueOfPosts) },state)
  ),
  on(
    nextPostsSuccessAction,
    (state,action) => adapter.updateOne(
      {
        id : action.postId,
        changes : {
          posts : addMany(
            action.payload.map(x => x.id),
            takeValueOfPosts,
            state.entities[action.postId]!.posts
          )
        }
      },
      state
    )
  )
)
