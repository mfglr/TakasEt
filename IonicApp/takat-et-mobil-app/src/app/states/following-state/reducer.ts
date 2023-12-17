import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { initFollowingStateAction, initFollowingStatesAction, changeFollowedValueAction } from "./actions";

export interface FollowingState {
  userId : number,
  isFollower : boolean,
  isFollowed : boolean,
  numberOfFollowers : number,
  numberOfFolloweds : number,
}
export interface EntityFollowingState extends EntityState<FollowingState>{}
const adapter = createEntityAdapter<FollowingState>({selectId : state => state.userId})

export const entityFollowingReducer = createReducer(
  adapter.getInitialState(),
  on(
    initFollowingStateAction,
    (state,action) => adapter.addOne({
      userId : action.user.id,
      numberOfFollowers : action.user.countOfFollowers,
      numberOfFolloweds : action.user.countOfFolloweds,
      isFollowed : action.user.isFollowed,
      isFollower : action.user.isFollower,
    },state)
  ),
  on(
    initFollowingStatesAction,
    (state,action) => adapter.addMany(action.users.map( (user) : FollowingState => ({
      userId : user.id,
      numberOfFollowers : user.countOfFollowers,
      numberOfFolloweds : user.countOfFolloweds,
      isFollowed : user.isFollowed,
      isFollower : user.isFollower,
    })),state)
  ),
  on(
    changeFollowedValueAction,
    (state,action) => {
      let isFollowed = state.entities[action.userId]!.isFollowed;
      let numberOfFollowers = state.entities[action.userId]!.numberOfFollowers;
      let vector;
      if(isFollowed && !action.value) vector = -1;
      else if(!isFollowed && action.value) vector = 1;
      else vector = 0
      return adapter.updateOne({
        id : action.userId,
        changes : { isFollowed : action.value, numberOfFollowers : numberOfFollowers + vector }
      },state)
    }
  )
)
