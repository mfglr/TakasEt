import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, initialPageOfComments, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export const commentsOfCommentQueryId = "commentsOfCommentQueryId" // + commentId

export interface ChildState extends AppEntityState<CommentResponse>{
    remainingCount : number;
    displayedCount : number;
    visibility : boolean;
}
export interface ParentState extends EntityState<ChildState>{}
export interface AppChildCommentState{ parentState : ParentState }

export const childAdapter = createEntityAdapter<CommentResponse>({ 
    selectId : state => state.id,
    sortComparer : (x,y) => x.createdDate  < y.createdDate ? 1 : 0
})
export const parentAdapter = createEntityAdapter<ChildState> ({ selectId : state => state.queryId })

export const initialState : AppChildCommentState = { parentState : parentAdapter.getInitialState() }

function addCommentsToChildState(comments : CommentResponse[], parentComment : CommentResponse,childState : ChildState) : ChildState{
    return {
        ...childAdapter.addMany(comments,childState),
        status : comments.length < takeValueOfComments,
        page : {...childState.page, skip : childState.page.skip + takeValueOfComments},
        displayedCount : childState.displayedCount + comments.length,
        remainingCount : childState.remainingCount - comments.length
    }
}
export function addComment(comment : CommentResponse,parentComment: CommentResponse,parentState : ParentState) : ParentState{
    let queryId = commentsOfCommentQueryId + parentComment.id;
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId,
            displayedCount : 0,
            remainingCount : parentComment.countOfChildren,
            visibility : true
        });
    return parentAdapter.setOne(childAdapter.addOne(comment,childState),parentState);
}
export function loadComments(comments : CommentResponse[],parentComment : CommentResponse,parentState : ParentState) : ParentState {
    let queryId = commentsOfCommentQueryId + parentComment.id;
    let childState : ChildState = parentState.entities[queryId] != undefined ? 
        parentState.entities[queryId]! : 
        childAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments},
            queryId : queryId,
            displayedCount : 0,
            remainingCount : parentComment.countOfChildren,
            visibility : true
        });
    return parentAdapter.setOne(addCommentsToChildState(comments,parentComment,childState),parentState);
}

export function switchVisibility(parentCommentId : string,parentState : ParentState) : ParentState{
    let queryId = commentsOfCommentQueryId + parentCommentId;
    if(parentState.entities[queryId])
        return parentAdapter.updateOne(
            { id : queryId, changes : { visibility : !(parentState.entities[queryId]!.visibility) } },parentState
        )
    return parentState;
}

export function setVisibile(parentCommentId : string,parentState : ParentState) : ParentState{
    let queryId = commentsOfCommentQueryId + parentCommentId;
    if(parentState.entities[queryId])
        return parentAdapter.updateOne(
            { id : queryId, changes : { visibility : true } },parentState
        )
    return parentState;
}