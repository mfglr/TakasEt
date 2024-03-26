import { createReducer, on } from "@ngrx/store";
import { addAction, removeAction } from "./actions";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export interface TestState{
  pipe : EntityState<number>
}

export const pipeAdapter = createEntityAdapter<number>({
  selectId : state => state
})

export const testReducer = createReducer(
  { pipe : pipeAdapter.addMany([5,4,3,2,1],pipeAdapter.getInitialState())  } ,

  on( addAction, (state,action) => {
    return state;
  }),
  on(
    removeAction,(state,action) => {
    let s = {pipe : pipeAdapter.removeOne(action.id,state.pipe)}
    console.log(s);
    return s;
  })
)
