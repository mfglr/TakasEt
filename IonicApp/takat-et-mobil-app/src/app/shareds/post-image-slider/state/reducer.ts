import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { ImageState } from "src/app/states/app-states";
import { initPostImageSliderAction, loadPostImageSuccessAction } from "./actions";

export interface PostImageState extends ImageState{}
export interface PostImageSliderState{
    postId : number;
    postImages : PostImageState[];
    countOfImages : number;
    activeIndex : number;
}
export interface EntityPostImageSliderState extends EntityState<PostImageSliderState>{}

const adapter = createEntityAdapter<PostImageSliderState>({
    selectId : state => state.postId
})
export const postImageSliderReducer = createReducer(
    adapter.getInitialState(),
    on(
        initPostImageSliderAction,
        (state,action) => adapter.addOne({
            countOfImages : action.post.countOfImages,
            activeIndex : 0,
            postId : action.post.id,
            postImages : action.post.postImages.map(
                (x) : PostImageState => ({ id : x.id, loadStatus : false, url : undefined })
            )
        },state)
    ),
    on(
        loadPostImageSuccessAction,
        (state,action) => {
            let postImages = [...state.entities[action.postId]!.postImages];
            postImages[action.index] = {
                id : postImages[action.index].id,
                url :  action.url,
                loadStatus : true
            }
            return adapter.updateOne({
                id : action.postId,
                changes : {
                    postImages : postImages
                } 
            },state)
        }
    )
)