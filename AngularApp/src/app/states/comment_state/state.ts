import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, initialPageOfComments, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export const commentsOfPostsQueryId = "commentsOfPostsQueryId" // + postId
export const commentsOfCommentQueryId = "commentsOfCommentQueryId" // + commentId

export interface CommentState{ comment : CommentResponse; countOfRemainingChildComments : number; childrenVisibility : boolean; }
export interface ChildState extends AppEntityState<CommentState>{}
export interface ParentState extends EntityState<ChildState>{}
export interface AppCommentState{ parentState : ParentState }

export const childAdapter = createEntityAdapter<CommentState>({ selectId : state => state.comment.id })
export const parentAdapter = createEntityAdapter<ChildState> ({ selectId : state => state.queryId })

export const initialState : AppCommentState = {
    parentState : parentAdapter.getInitialState(),
}

function createCommentState(comment: CommentResponse) : CommentState{
    return { comment: comment,childrenVisibility : false, countOfRemainingChildComments : comment.countOfChildren }
}
function createCommentStates(comments : CommentResponse[]) : CommentState[]{
    return comments.map(x => createCommentState(x));
}
function addCommentsToChildState(comments : CommentResponse[],childState : ChildState) : ChildState{
    return {
        ...childAdapter.addMany(createCommentStates(comments),childState),
        status : comments.length < takeValueOfComments,
        page : {...childState.page, skip : childState.page.skip + takeValueOfComments},
    }
}
export function addComment(comment : CommentResponse,queryId : string,parentState : ParentState) : ParentState{
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId,
        });
    return parentAdapter.addOne(childAdapter.addOne(createCommentState(comment),childState),parentState);
}
export function loadComments(comments : CommentResponse[],queryId : string,parentState : ParentState) : ParentState{
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId
        });
    return parentAdapter.setOne(addCommentsToChildState(comments,childState),parentState);
}
function switchChildrenVisibilityOfChildState(parentCommentId : string,childState : ChildState) : ChildState{
    let commentState = childState.entities[parentCommentId];
    if(commentState)
        return childAdapter.updateOne({
            id : parentCommentId,
            changes : {
                ...commentState,
                childrenVisibility : !(commentState.childrenVisibility)
            }
        },childState)
    return childState;
}
export function switchChildrenVisibility(queryId : string,parentCommentId : string,parentState : ParentState) : ParentState{
    let childState = parentState.entities[queryId];
    if(childState)
        return parentAdapter.updateOne({
            id : queryId,
            changes : switchChildrenVisibilityOfChildState(parentCommentId,childState)
        },parentState);
    return parentState;
}