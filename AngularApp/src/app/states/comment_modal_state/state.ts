import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, initialPageOfComments, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export interface CommentToReplyState{
    ownerId : string;
    ownerType : "post" | "comment";
    comment : CommentResponse | undefined;
}
export interface CommentState{
    comment : CommentResponse;
    children : AppEntityState<CommentResponse>;
    remainingChildrenCount : number;
    displayedChildrenCount : number;
    childrenVisibility : boolean;
}
export interface CommentModalState extends AppEntityState<CommentState>{
    postId : string;
    commentToReplyState : CommentToReplyState;
}
export interface CommentModalStateCollection extends EntityState<CommentModalState>{}

export const childrenAdapter = createEntityAdapter<CommentResponse>({
    selectId : state => state.id,
    sortComparer : (x,y) => x.createdDate < y.createdDate ? 1 : 0
})
export const commentModalAdapter = createEntityAdapter<CommentState>({
    selectId : state => state.comment.id,
    sortComparer : (x,y) => x.comment.createdDate < y.comment.createdDate ? 1 : 0
})
export const stateAdapter = createEntityAdapter<CommentModalState>({
    selectId : state => state.postId
})

export const initialState : CommentModalStateCollection = stateAdapter.getInitialState({})

function createCommentState(comment : CommentResponse) : CommentState{
    return {
        children : childrenAdapter.getInitialState({
            status : false,
            page : {...initialPageOfComments}
        }),
        comment : comment,
        childrenVisibility : false,
        displayedChildrenCount : 0,
        remainingChildrenCount : comment.countOfChildren
    }
}
function createCommentStates(comments : CommentResponse[]) : CommentState[]{
    return comments.map(x => createCommentState(x));
}
function addComment(comment : CommentResponse,postId : string,state : CommentModalStateCollection){
    let commentModalState = state.entities[postId]!;
    return stateAdapter.updateOne({
        id : postId,
        changes : commentModalAdapter.addOne(createCommentState(comment),commentModalState)
    },state)
}
function addChild(comment : CommentResponse,postId : string,commentId : string,state : CommentModalStateCollection){
    let commentModalState = state.entities[postId]!
    let commentState = commentModalState.entities[commentId]!
    let children = commentState.children
    return stateAdapter.updateOne({
        id : postId,
        changes : commentModalAdapter.updateOne({
            id : commentId,
            changes : {
                children : childrenAdapter.addOne(comment,children),
                childrenVisibility : true,
                comment : {...commentState.comment,countOfChildren : commentState.comment.countOfChildren + 1},
                displayedChildrenCount : commentState.displayedChildrenCount + 1
            }
        },commentModalState)
    },state)
}
export function add(comment : CommentResponse, postId : string,state : CommentModalStateCollection){
    let c = state.entities[postId]!.commentToReplyState;
    if(c.ownerType == "post")
        addComment(comment,postId,state)
    else
        addChild(comment,postId,c.ownerId,state)
}
export function loadChildren(comments : CommentResponse[],postId : string,commentId : string,state : CommentModalStateCollection) : CommentModalStateCollection{
    let commentModalState = state.entities[postId]!
    let commentState = commentModalState.entities[commentId]!
    let children = commentState.children
    let page = children.page
    return stateAdapter.updateOne({
        id : postId,
        changes : commentModalAdapter.updateOne({
            id : commentId,
            changes : {
                children : {
                    ...childrenAdapter.addMany(comments,children),
                    status : comments.length < takeValueOfComments,
                    page : {...page,skip : page.skip + takeValueOfComments }
                },
                childrenVisibility : true,
                displayedChildrenCount : commentState.displayedChildrenCount + comments.length,
                remainingChildrenCount : commentState.remainingChildrenCount - comments.length
            }
        },commentModalState)
    },state)

}
export function loadComments(comments : CommentResponse[],postId : string,state : CommentModalStateCollection){
    let commentModalState : CommentModalState = state.entities[postId]!;
    return stateAdapter.updateOne(
        {
            id : postId,
            changes : {
                ...commentModalAdapter.addMany(createCommentStates(comments),commentModalState),
                status : comments.length < takeValueOfComments,
                page : {...commentModalState.page,skip : commentModalState.page.skip + takeValueOfComments}
            }
        },
        state
    );
}
export function switchVisibility(postId : string,commentId : string, state : CommentModalStateCollection) : CommentModalStateCollection{
    let commentModelState = state.entities[postId]!;
    let commentState = commentModelState.entities[commentId]!;
    return stateAdapter.updateOne({
        id : postId,
        changes : commentModalAdapter.updateOne({
            id : commentId,
            changes : { childrenVisibility : !commentState.childrenVisibility }
        },commentModelState)
    },state);
}
export function setCommentToReply(
    postId : string,
    ownerId : string,
    ownerType : "post" | "comment",
    comment : CommentResponse,
    state : CommentModalStateCollection
){
    return stateAdapter.updateOne({
        id : postId,
        changes : {
            commentToReplyState : {
                ownerId : ownerId,
                ownerType : ownerType,
                comment : comment
            }
        }
    },state)
}
export function resetCommentToReply(
    postId : string,
    state : CommentModalStateCollection
){
    return stateAdapter.updateOne({
        id : postId,
        changes : {
            commentToReplyState : {
                ownerId : postId,
                ownerType : "post",
                comment : undefined
            }
        }
    },state)
}
