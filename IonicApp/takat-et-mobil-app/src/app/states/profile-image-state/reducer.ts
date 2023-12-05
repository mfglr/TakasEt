import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadProfileImageSuccessAction, addProfileImageAction, addProfileImagesAction } from "./actions";
import { ProfileImageResponse } from "src/app/models/responses/profile-image-response";

export interface ProfileImageState{
    profileImage : ProfileImageResponse;
    loadStatus : boolean;
    url : string | undefined;
}
export interface EntityProfileImageState extends EntityState<ProfileImageState>{}
const adapter = createEntityAdapter<ProfileImageState>({
    selectId : state => state.profileImage.id
})

export const profileImageReducer = createReducer(
    adapter.getInitialState(),
    on(
        loadProfileImageSuccessAction,
        (state,action) => adapter.updateOne({
            id : action.id,
            changes : { loadStatus : true, url : action.url }
        },state)
    ),
    on(
        addProfileImageAction,
        (state,action) => {
            if(action.image)
                return adapter.addOne({
                    profileImage : action.image,
                    loadStatus : false,
                    url : undefined
                },state)
            return state
        }
    ),
    on(
        addProfileImagesAction,
        (state,action) => adapter.addMany(
            action.images.filter(x => !(!x)).map( (x) : ProfileImageState => ({
                profileImage : x!,
                loadStatus : false,
                url : undefined
            })),state
        )
    )
)