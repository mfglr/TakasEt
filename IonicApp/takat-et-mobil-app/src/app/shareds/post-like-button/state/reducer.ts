import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { commitSuccessAction, initStateAction, switchAction } from "./actions";

export interface PostLikeState{
    postId : number;
    likeStatus : boolean;
    countOfLikes : number;
    lastComittedValue : boolean | undefined;
}
export interface EntityPostLikeState extends EntityState<PostLikeState>{}
const adapter = createEntityAdapter<PostLikeState>({ selectId : x => x.postId })

export const postLikeReducer = createReducer(
    adapter.getInitialState(),
    on(
        initStateAction,
        (state,action) => adapter.addOne({
            countOfLikes : action.countOfLikes,
            lastComittedValue : undefined,
            likeStatus : action.likeStatus,
            postId : action.postId
        },state)
    ),
    on(
        switchAction,
        (state,action) => {
            let postLikeState = state.entities[action.postId]!
            let currentStatus = postLikeState.likeStatus;
            let countsOfLike = postLikeState.countOfLikes;
            let vector = currentStatus ? -1 : 1
            return adapter.updateOne({
                id : action.postId,
                changes : { likeStatus : !currentStatus, countOfLikes : countsOfLike + vector }
            },state)
        }
    ),
    on(
        commitSuccessAction,
        (state,action) => adapter.updateOne({
            id : action.postId,
            changes : { lastComittedValue : action.value }
        },state)
    ),
)