import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { takeValueOfComments } from 'src/app/states/app-states';
import { nextPageOfChildren, setSelectedCommentId } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';
import { selectCommentReponsesOfCommentResponse } from 'src/app/states/home-page/selectors';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  children$? : Observable<CommentResponse[]>
  remainingChildCommentCounts = 0;
  mode : Mode = new Mode(2)

  constructor(
    public commentLikingService : UserCommentLikingService,
    private homeStore : Store<HomePageState>
  ) {}

  ngOnChanges(){
    if(this.comment && this.comment.countOfChildren > 0){
      this.remainingChildCommentCounts = this.comment.countOfChildren
      this.children$ = this.homeStore.select(
        selectCommentReponsesOfCommentResponse({postId : this.comment.postId!,commentId : this.comment.id})
      );
    }
  }
  loadChildren(){
    if(this.comment && this.comment.countOfChildren > 0){
      this.homeStore.dispatch(nextPageOfChildren())
      this.remainingChildCommentCounts = this.remainingChildCommentCounts - takeValueOfComments;
      this.mode = new Mode(2,1);
    }
  }
  hover(){
    if(this.comment)
      this.homeStore.dispatch(setSelectedCommentId({ commentId : this.comment.id}))
  }

  commentToParent(){
  }
}
