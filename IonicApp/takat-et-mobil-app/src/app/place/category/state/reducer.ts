import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { AppEntityState,takeValueOfPosts } from "src/app/state/app-entity-state/app-entity-state";
import { initCategoryPageState, nextPostsSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";

export interface CategoryPageState{
  categoryId : number;
  posts : AppEntityState<PostResponse>;
}
export interface CategoryPageCollectionState extends EntityState<CategoryPageState>{}
const adapter = createEntityAdapter<CategoryPageState>({selectId : state => state.categoryId})

export const CategoryPageCollectionReducer = createReducer(
  adapter.getInitialState(),
  // on(
  //   initCategoryPageState,
  //   (state,action) => adapter.addOne({
  //     categoryId : action.categoryId,
  //     posts : init(takeValueOfPosts)
  //   },state)
  // ),
  // on(
  //   nextPostsSuccessAction,
  //   (state,action) => adapter.updateOne({
  //     id : action.categoryId,
  //     changes : {
  //       posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.entities[action.categoryId]!.posts)
  //     }
  //   },state)
  // )
)
