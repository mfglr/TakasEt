import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, initialPageOfComments, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export const commentsOfPostQueryId = "commentsOfPostQueryId" // + postId

export interface ChildState extends AppEntityState<CommentResponse>{}
export interface ParentState extends EntityState<ChildState>{}
export interface AppCommentState{ parentState : ParentState }

export const childAdapter = createEntityAdapter<CommentResponse>({ selectId : state => state.id })
export const parentAdapter = createEntityAdapter<ChildState> ({ selectId : state => state.queryId })

export const initialState : AppCommentState = { parentState : parentAdapter.getInitialState() }

function addCommentsToChildState(comments : CommentResponse[],childState : ChildState) : ChildState {
    return {
        ...childAdapter.addMany(comments,childState),
        status : comments.length < takeValueOfComments,
        page : { ...childState.page, skip : childState.page.skip + takeValueOfComments },
    }
}
export function addComment(comment : CommentResponse,postId : string,parentState : ParentState) : ParentState{
    let queryId = commentsOfPostQueryId + postId;
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId,
        });
    return parentAdapter.addOne(childAdapter.addOne(comment,childState),parentState);
}
export function loadComments(comments : CommentResponse[],postId : string,parentState : ParentState) : ParentState{
    let queryId = commentsOfPostQueryId + postId;
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId
        });
    return parentAdapter.setOne(addCommentsToChildState(comments,childState),parentState);
}
