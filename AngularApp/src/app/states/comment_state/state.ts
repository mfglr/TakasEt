import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, initialPageOfComments, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export const commentsOfPostsQueryId = "commentsOfPostsQueryId" // + postId
export const commentsOfCommentQueryId = "commentsOfCommentQueryId" // + commentId

export interface ChildState extends AppEntityState<CommentResponse>{}
export interface ParentState extends EntityState<ChildState>{}
export interface AppCommentState{ parentState : ParentState }

export const childAdapter = createEntityAdapter<CommentResponse>({ selectId : state => state.id })
export const parentAdapter = createEntityAdapter<ChildState> ({ selectId : state => state.queryId })

export const initialState : AppCommentState = {
    parentState : parentAdapter.getInitialState(),
}

function addPostsToChildState(posts : CommentResponse[],childState : ChildState) : ChildState{
    return {
        ...childAdapter.addMany(posts,childState),
        status : posts.length < takeValueOfComments,
        page : {...childState.page, skip : childState.page.skip + takeValueOfComments},
    }
}
export function addComment(post : CommentResponse,queryId : string,parentState : ParentState) : ParentState{
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId,
        });
    return parentAdapter.addOne(childAdapter.addOne(post,childState),parentState);
}
export function loadComments(posts : CommentResponse[],queryId : string,parentState : ParentState) : ParentState{
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId
        });
    return parentAdapter.setOne(addPostsToChildState(posts,childState),parentState);
}
