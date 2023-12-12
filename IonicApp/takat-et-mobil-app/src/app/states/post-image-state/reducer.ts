import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadPostImageSuccessAction, loadPostImagesSuccessAction, loadPostImageUrlSuccessAction } from "./actions";
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
      loadPostImagesSuccessAction,
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
      loadPostImageSuccessAction,
      (state,action) => adapter.addOne({
        postImage : action.postImage,
        loadStatus : false,
        url : undefined
      },state)
    ),
    on(
      loadPostImageUrlSuccessAction,
      (state,action) => adapter.updateOne({
        id : action.id,
        changes : { loadStatus : true, url : action.url }
      },state)
    )
)
