import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { changeActiveTabAction, initUserPageStateAction } from "./actions";

interface UserPageState{
  userId : number;
  activeTab : number;
}
export interface UserPageCollectionState extends EntityState<UserPageState>{
  activeUserPage : number | undefined
}

const adapter = createEntityAdapter<UserPageState>({
  selectId : x => x.userId
})

const initialState : UserPageCollectionState = adapter.getInitialState({
  activeUserPage : undefined
})
export const userPageCollectionReducer = createReducer(
  initialState,
  on(
    changeActiveTabAction,
    (state,action) => adapter.updateOne({ id : action.userId, changes : { activeTab : action.activeTab } },state)
  ),
  on(
    initUserPageStateAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      activeTab : 0,
    },state)
  ),
)
