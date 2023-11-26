import { PostResponse } from "src/app/models/responses/post-response";
import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { PostFilterRequest } from "src/app/models/requests/post-filter-request";

export const noImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/495px-No-Image-Placeholder.svg.png?20200912122019"

export const homePagePostList = "homePagePostList";
export const searchPagePostList = "searchPagePostList";
export const profilePagePostList = "profilePagePostList"

export interface ImageState{ url : string; isLoad : boolean; }
export interface PostState{
    post : PostResponse;
    postImages : ImageState[];
    currentPostImageIndex : number;
    profileImage : ImageState;
}
export interface EntityPostState extends EntityState<PostState>{
    pageId : string;
    status : boolean;
    filter : PostFilterRequest
}
export interface PagePostState extends EntityState<EntityPostState>{}

export const entityPostAdapter = createEntityAdapter<PostState>({selectId : state => state.post.id})
export const pagePostAdapter = createEntityAdapter<EntityPostState>({selectId : state => state.pageId})

export function createPostState(post : PostResponse) : PostState{
    let images : ImageState[] = []
    for(var i = 0; i < post.countOfImages; i++)
        images[i] = { url : noImageUrl, isLoad : false }
    return { postImages : images, profileImage : { url : noImageUrl, isLoad : false }, currentPostImageIndex : 0, post : post }
}
export function createPostStates(posts : PostResponse[]) : PostState[]{
    return posts.map(post => createPostState(post));
}