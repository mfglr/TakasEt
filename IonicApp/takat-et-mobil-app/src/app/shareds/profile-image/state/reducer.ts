import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { ImageState } from "src/app/states/app-states";
import { loadProfileImageSuccessAction } from "./actions";

export interface ProfileImageState extends ImageState{
}
export interface EntityProfileImageState extends EntityState<ProfileImageState>{}
const adapter = createEntityAdapter<ProfileImageState>({
    selectId : state => state.id
})

export const profileImageReducer = createReducer(
    adapter.getInitialState(),
    on(
        loadProfileImageSuccessAction,
        (state,action) => adapter.addOne({
            url : action.url,
            id : action.id,
            loadStatus : true,
        },state)
    )
)