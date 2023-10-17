import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @Input() posts? : PostResponse[] | undefined | null;
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;
  post? : PostResponse;
  getCommentButtonEvent(post : PostResponse){
    this.post = post;
    if(this.commentModalButton) this.commentModalButton.nativeElement.click();
  }
  getPostCommentCountVector(countVector : number){
    if(this.post)
      this.post.countOfComments += countVector;
  }
}
