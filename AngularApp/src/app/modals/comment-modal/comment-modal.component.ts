import { Component, ElementRef, Input, OnChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store} from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { Observable, filter, fromEvent, map, withLatestFrom } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { AppCommentState } from 'src/app/states/comment_state/state';
import * as appCommentSelectors from 'src/app/states/comment_state/selectors';
import * as appCommentActions from 'src/app/states/comment_state/actions';
import * as appChildCommentActions from 'src/app/states/child_comment_state/actions';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { AppLoginState } from 'src/app/states/login_state/state';
import { AppChildCommentState } from 'src/app/states/child_comment_state/state';
import { RepliedCommentState } from 'src/app/states/replied_comment_state/state';
import { selectStatus, selectRepliedCommentState,selecUserName } from 'src/app/states/replied_comment_state/selectors';
import { resetAction } from 'src/app/states/replied_comment_state/actions';
import { setVisibileAction } from 'src/app/states/child_comment_state/actions';

@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges {
  @Input() post? : PostResponse;
  @ViewChild("shareCommentButton",{static : true}) shareCommentButton? : ElementRef;
  
  comments$? : Observable<CommentResponse[]>;
  userName$ = this.repliedCommentStore.select(selecUserName);
  status$ = this.repliedCommentStore.select(selectStatus)

  commentForm = new FormGroup({
    content : new FormControl<string>('')
  });

  constructor(
    private loginStore : Store<AppLoginState>,
    private commentStore : Store<AppCommentState>,
    private childCommentStore : Store<AppChildCommentState>,
    private repliedCommentStore : Store<RepliedCommentState>
  ) {}

  ngOnChanges() {
    if(this.post){
      this.comments$ = this.commentStore.select(appCommentSelectors.selectResponses({postId : this.post.id}))
    }
  }
 
  ngAfterContentInit(){
      fromEvent(this.shareCommentButton?.nativeElement,"click").pipe(
        withLatestFrom(
          this.repliedCommentStore.select(selectRepliedCommentState),
          this.loginStore.select(selectUserId),
          this.commentForm.valueChanges
        ),
        filter(([event,state,userId,form]) =>!!userId && !!form.content),
        map(([event,state,userId,form]) => {
          if(this.post)
            this.shareComment(form.content!,userId!,this.post.id,state)
        })
      ).subscribe();
  }

  getMore(){
    if(this.post){
      this.commentStore.dispatch(appCommentActions.nextPageAction({postId : this.post.id}))
    }
  }
  resetRepliedCommentState(){
    this.repliedCommentStore.dispatch(resetAction());
  }
  shareComment( content : string, userId : string, postId : string, state : RepliedCommentState){
    if(state.parentComment && state.comment){
      this.childCommentStore.dispatch( appChildCommentActions.addAction({
        request : { content : content,userId : userId,parentId : state.parentComment.id },
        parentComment : state.parentComment
      }))
    }
    else if(state.comment && !state.parentComment){
      this.childCommentStore.dispatch(appChildCommentActions.addAction({
        request : { content : content,userId : userId, parentId : state.comment.id },
        parentComment : state.comment
      }))
      this.childCommentStore.dispatch(setVisibileAction({parentCommentId : state.comment.id}));
    }
    else if(!state.parentComment && !state.comment){
      this.commentStore.dispatch(appCommentActions.addAction({
        request : { content : content,userId : userId,postId : postId }
      }))
    }
  }

}
