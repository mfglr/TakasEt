import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadProfileImageUrlSuccessAction, loadProfileImageSuccessAction, loadProfileImagesSuccessAction } from "./actions";
import { ProfileImageResponse } from "src/app/models/responses/profile-image-response";

interface ProfileImage{
    profileImage : ProfileImageResponse;
    loadStatus : boolean;
    url : string | undefined;
}
export interface ProfileImageState extends EntityState<ProfileImage>{}

const adapter = createEntityAdapter<ProfileImage>({ selectId : x => x.profileImage.id })

export const profileImageReducer = createReducer(
  adapter.getInitialState(),
  on(
    loadProfileImageUrlSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.id,
      changes : { loadStatus : true, url : action.url }
    },state)
  ),
  on(
    loadProfileImageSuccessAction,
    (state,action) => {
      if(action.image)
        return adapter.addOne({ profileImage : action.image, loadStatus : false, url : undefined },state)
      return state
    }
  ),
  on(
    loadProfileImagesSuccessAction,
    (state,action) => adapter.addMany(
      action.images.filter(x => !(!x)).map( (x) : ProfileImage => ({
        profileImage : x!,
        loadStatus : false,
        url : undefined
      })),state
    )
  )
)
