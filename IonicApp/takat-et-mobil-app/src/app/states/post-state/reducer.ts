import { createReducer, on } from "@ngrx/store";
import { createPostStates, entityPostAdapter, homePagePostList, pagePostAdapter, searchPagePostList} from "./state";
import { initHomePageAction, initSearchPageAction,loadPostImageSuccessAction, loadProfileImageSuccessAction, nextPageSuccessAction, setCurrentIndexOfPostImagesAction,switchLikeStatusSuccessAction } from "./actions";
import { createPostFilterForHomePage, createPostFilterForSearchingPage, takeValueOfPosts } from "../app-states";


export const pagePostReducer = createReducer(
    pagePostAdapter.getInitialState(),
    on(
        nextPageSuccessAction,
        (state,action) => pagePostAdapter.updateOne(
            {
                id : action.pageId,
                changes : {
                    ...entityPostAdapter.addMany(createPostStates(action.payload),state.entities[action.pageId]!),
                    status : action.payload.length < takeValueOfPosts,
                    filter : {
                        ...state.entities[action.pageId]!.filter,
                        skip : state.entities[action.pageId]!.filter.take + takeValueOfPosts
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
    ),
    on(
        switchLikeStatusSuccessAction,
        (state,action) => {
            let post = state.entities[action.pageId]!.entities[action.postId]!.post;
            let likeStatus = post.likeStatus;
            let vector = likeStatus ? -1 : 1;
            return pagePostAdapter.updateOne({
                id : action.pageId,
                changes : entityPostAdapter.updateOne({
                    id : action.postId,
                    changes : {
                        post : {
                            ...post,
                            countOfLikes : post.countOfLikes + vector,
                            likeStatus : !likeStatus
                        },
                    }
                },state.entities[action.pageId]!)
            },state)
        }
    ),
    on(
        initHomePageAction,
        (state) => pagePostAdapter.addOne(
            entityPostAdapter.getInitialState({
                pageId : homePagePostList,
                filter : createPostFilterForHomePage(),
                status : false
            }),
            state
        )
    ),
    on(
        initSearchPageAction,
        (state) => pagePostAdapter.addOne(
            entityPostAdapter.getInitialState({
                pageId : searchPagePostList,
                status : false,
                filter : createPostFilterForSearchingPage()
            }),
            state
        )
    )
    
)