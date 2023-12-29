import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadUserImageUrlSuccessAction, loadUserImageSuccessAction, loadUserImagesSuccessAction } from "./actions";
import { UserImageResponse } from "src/app/models/responses/profile-image-response";

interface UserImageState{
    profileImage : UserImageResponse;
    loadStatus : boolean;
    url : string | undefined;
}
export interface UserImageEntityState extends EntityState<UserImageState>{}

const adapter = createEntityAdapter<UserImageState>({ selectId : x => x.profileImage.id })

export const userImageEntityReducer = createReducer(
  adapter.getInitialState(),
  on(
    loadUserImageUrlSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.id,
      changes : { loadStatus : true, url : action.url }
    },state)
  ),
  on(
    loadUserImageSuccessAction,
    (state,action) => {
      if(action.image)
        return adapter.addOne({ profileImage : action.image, loadStatus : false, url : undefined },state)
      return state
    }
  ),
  on(
    loadUserImagesSuccessAction,
    (state,action) => adapter.addMany(
      action.images.filter(x => !(!x)).map( (x) : UserImageState => ({
        profileImage : x!,
        loadStatus : false,
        url : undefined
      })),state
    )
  )
)
