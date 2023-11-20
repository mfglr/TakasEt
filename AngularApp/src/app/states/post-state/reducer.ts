import { createReducer, on } from "@ngrx/store";
import { createPostStates, entityPostAdapter, homePagePostList, pagePostAdapter, profilePagePostList, searchPagePostList } from "./state";
import { loadPostImageSuccessAction, loadProfileImageSuccessAction, nextPageSuccessAction, setCurrentIndexOfPostImagesAction } from "./actions";
import { initialPageOfPosts, takeValueOfPosts } from "../app-states";

const initialState = pagePostAdapter.addMany(
    [
        entityPostAdapter.getInitialState({ pageId : homePagePostList, page : {...initialPageOfPosts}, status : false }),
        entityPostAdapter.getInitialState({ pageId : searchPagePostList, page : {...initialPageOfPosts}, status : false }),
        entityPostAdapter.getInitialState({ pageId : profilePagePostList, page : {...initialPageOfPosts}, status : false }),
    ],
    pagePostAdapter.getInitialState()
)

export const collectionPostReducer = createReducer(
    initialState,
    on(
        nextPageSuccessAction,
        (state,action) => pagePostAdapter.updateOne(
            {
                id : action.pageId,
                changes : {
                    ...entityPostAdapter.addMany(createPostStates(action.payload),state.entities[action.pageId]!),
                    status : action.payload.length < takeValueOfPosts,
                    page : {
                        ...state.entities[action.pageId]!.page,
                        skip : state.entities[action.pageId]!.page.take + takeValueOfPosts
                    }
                }
            },
            state
        )
    ),
    on(
        loadPostImageSuccessAction,
        (state,action) => {
            let postImages = [...state.entities[action.pageId]!.entities[action.postId]!.postImages]
            postImages[action.index] = { url : action.url, isLoad : true}
            return pagePostAdapter.updateOne({
                id : action.pageId,
                changes : entityPostAdapter.updateOne(
                    { id : action.postId, changes : { postImages : postImages } },
                    state.entities[action.pageId]!
                )
            },state)
        }
    ),
    on(
        loadProfileImageSuccessAction,
        (state,action) => pagePostAdapter.updateOne({
            id : action.pageId,
            changes : entityPostAdapter.updateOne({
                id : action.postId,
                changes : { profileImage : { isLoad : true,url : action.url } }
            },state.entities[action.pageId]!)
        },state)
    ),
    on(
        setCurrentIndexOfPostImagesAction,
        (state,action) => pagePostAdapter.updateOne({
            id : action.pageId,
            changes : entityPostAdapter.updateOne({
                id : action.postId,
                changes : { currentPostImageIndex : action.index }
            },state.entities[action.pageId]!)
        },state)
    )
)