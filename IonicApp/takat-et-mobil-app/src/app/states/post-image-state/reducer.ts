import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { addPostImage, addPostImagesAction, loadPostImageSuccessAction } from "./actions";
import { PostImageResponse } from "src/app/models/responses/post-image-response";

export interface PostImageState{
    postImage : PostImageResponse;
    loadStatus : boolean;
    url : string | undefined;
}
export interface State extends EntityState<PostImageState>{}

const adapter = createEntityAdapter<PostImageState>({selectId : state => state.postImage.id})

export const postImageReducer = createReducer(
    adapter.getInitialState(),
    on(
        addPostImagesAction,
        (state,action) => adapter.addMany( 
            action.postImages.map(
                (postImage) : PostImageState => ({
                    postImage : postImage,
                    loadStatus : false,
                    url : undefined
                })
            ),state
        )
    ),
    on(
        addPostImage,
        (state,action) => adapter.addOne({
            postImage : action.postImage,
            loadStatus : false,
            url : undefined
        },state)
    ),
    on(
        loadPostImageSuccessAction,
        (state,action) => adapter.updateOne({
            id : action.id,
            changes : { loadStatus : true, url : action.url }
        },state)
    )
)
