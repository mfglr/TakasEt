import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { initSearchPostListPageStateAction, nextPostsSuccessAction } from "./actions";
import { AppEntityState, addMany, takeValueOfPosts } from "src/app/states/app-entity-state/app-entity-state";

interface SearchPostListPageState{
  posts : AppEntityState,
  postId : number
}
export interface EntitySearchPostListPageState extends EntityState<SearchPostListPageState>{}

const adapter = createEntityAdapter<SearchPostListPageState>({selectId : state => state.postId})

export const entitySearcPostListPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initSearchPostListPageStateAction,
    (state,action) => adapter.addOne({
      postId : action.postId,
      posts : {
        entityIds : [action.postId],
        isLastEntities : false,
        page : {
          lastId : action.postId,
          take : takeValueOfPosts
        }
      }
    },state)
  ),
  on(
    nextPostsSuccessAction,
    (state,action) => {
      let appEntityState = state.entities[action.postId]!.posts;
      return adapter.updateOne({
        id : action.postId,
        changes : { posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,appEntityState) }
      },state)
    }
  )
)
