import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, createPage, takeValueOfComments } from "../app-states";
import { EntityState, createEntityAdapter } from "@ngrx/entity";

export interface CommentToReplyState{
    ownerId : number;
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
    postId : number;
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

export const initialState : CommentModalStateCollection = stateAdapter.getInitialState()

function createCommentState(comment : CommentResponse) : CommentState{
    return {
        children : childrenAdapter.getInitialState({
            status : false,
            page : {...createPage(takeValueOfComments)}
        }),
        comment : comment,
        childrenVisibility : true,
        displayedChildrenCount : 0,
        remainingChildrenCount : comment.countOfChildren
    }
}
function createCommentStates(comments : CommentResponse[]) : CommentState[]{
    return comments.map(x => createCommentState(x));
}
function addComment(comment : CommentResponse,postId : number,state : CommentModalStateCollection){
    let commentModalState = state.entities[postId]!;
    return stateAdapter.updateOne({
        id : postId,
        changes : commentModalAdapter.addOne(createCommentState(comment),commentModalState)
    },state)
}
function addChild(comment : CommentResponse,postId : number,commentId : number,state : CommentModalStateCollection){
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
export function add(comment : CommentResponse, postId : number,state : CommentModalStateCollection){
    let c = state.entities[postId]!.commentToReplyState;
    if(c.ownerType === "post"){
        return addComment(comment,postId,state)
    }
    else{
        return addChild(comment,postId,c.ownerId,state)
    }
}
export function loadChildren(comments : CommentResponse[],postId : number,commentId : number,state : CommentModalStateCollection) : CommentModalStateCollection{
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
export function loadComments(comments : CommentResponse[],postId : number,state : CommentModalStateCollection){
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
export function switchVisibility(postId : number,commentId : number, state : CommentModalStateCollection) : CommentModalStateCollection{
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
    postId : number,
    ownerId : number,
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
    postId : number,
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
export function initCommentModalStates(postIds : number[],state : CommentModalStateCollection){
    return stateAdapter.addMany(
        postIds.map(
            postId =>
                commentModalAdapter.getInitialState({
                    status : false,
                    postId : postId,
                    page : {...createPage(takeValueOfComments)},
                    commentToReplyState : {
                        ownerId : postId,
                        ownerType : "post",
                        comment : undefined
                    }
                })
        ),state
    )
}
