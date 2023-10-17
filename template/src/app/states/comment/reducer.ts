import { createReducer, on } from '@ngrx/store';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import * as CommentActions from './actions';
import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';



export interface CommentState extends EntityState<CommentResponse>{
  respondedComment : CommentResponse | null;
}

export const adapter : EntityAdapter<CommentResponse> = createEntityAdapter<CommentResponse>();

const initialState : CommentState = adapter.getInitialState( {
  respondedComment : null,
});

export const commentReducer = createReducer(
  initialState,
  on(CommentActions.getCommentsByPostIdSuccess,(state,action) : CommentState =>{
    return adapter.addMany(action.comments,state);
  }),
  on(CommentActions.getCommentWithChildrenSuccess,(state,action) : CommentState => {
    return adapter.updateOne({id : action.payload.id,changes : action.payload},state);
  }),
  // on(CommentActions.addCommentSuccess,(state,action) : CommentState => {
  //   if(action.comment.postId)
  //     return {...state,comments : [action.comment,...state.comments]};
  //   return {...state,children : [action.comment,...state.children]};
  // }),
  // on(CommentActions.setRespondedComment,(state,action) : CommentState => {
  //   return {...state,respondedComment : action.comment}
  // }),
  // on(CommentActions.setParentComment,(state,action) : CommentState => {
  //   return {...state,parentComment : action.comment}
  // })
)

const { selectTotal,selectAll } = adapter.getSelectors();

export const selectRespondedComment = (state : CommentState) => state.respondedComment;
export const selectComments = selectAll;
export const selectCommentTotal = selectTotal;
