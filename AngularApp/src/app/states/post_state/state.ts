import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { PostResponse } from "src/app/models/responses/post-response";
import { AppEntityState, initialPageOfPosts, takeValueOfPosts } from "../app-states";

export const postsOfHomePageQueryId = "postsOfHomePageQueryId";

export interface ChildState extends AppEntityState<PostResponse>{
    queryId : string;
}
export interface ParentState extends EntityState<ChildState>{}
export interface AppPostState{ parentState : ParentState, selectedQueryId : string | undefined }

export const childAdapter = createEntityAdapter<PostResponse>({selectId : state => state.id})
export const parentAdapter = createEntityAdapter<ChildState>({selectId : state => state.queryId})

export const initialState : AppPostState = {
    parentState : parentAdapter.addOne(
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfPosts},
            queryId : postsOfHomePageQueryId
        }),
        parentAdapter.getInitialState()
    ),
    selectedQueryId : undefined
}

function addPostsToChildState(posts : PostResponse[],childState : ChildState) : ChildState{
    return {
        ...childAdapter.addMany(posts,childState),
        status : posts.length < takeValueOfPosts,
        page : {...childState.page, skip : childState.page.skip + takeValueOfPosts}
    }
}
export function addPost(post : PostResponse,queryId : string,parentState : ParentState) : ParentState{
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({ status : false, page : {...initialPageOfPosts}, queryId : queryId });
    return parentAdapter.addOne(childAdapter.addOne(post,childState),parentState);
}
export function loadPosts(posts : PostResponse[],queryId : string,parentState : ParentState) : ParentState{
    return parentAdapter.updateOne(
        { id : queryId, changes : addPostsToChildState(posts,parentState.entities[queryId]!) },
        parentState
    );
} 