import { PostResponse } from "src/app/models/responses/post-response";
import { AppEntityState } from "../app-states";
import { createEntityAdapter } from "@ngrx/entity";

export const noImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/495px-No-Image-Placeholder.svg.png?20200912122019"

export interface ImageState{
    url : string;
    isLoad : boolean;
}
export interface PostState{
    postImages : ImageState[];
    currentIndex : number;
    profileImage : ImageState;
    post : PostResponse;
}
export interface HomePageState{
    posts : AppEntityState<PostState>;
}
export const postStateAdapter = createEntityAdapter<PostState>({
    selectId : state => state.post.id
})
export function createPostState(post : PostResponse) : PostState{
    let images : ImageState[] = []
    for(var i = 0; i < post.countOfImages;i++)
        images[i] = { url : noImageUrl, isLoad : false }
    return { postImages : images,profileImage : { url : noImageUrl, isLoad : false }, currentIndex : 0,post : post}
}
export function createPostStates(posts : PostResponse[]) : PostState[]{
    return posts.map(post => createPostState(post));
}