import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentLikeButtonComponent } from './comment-like-button/comment-like-button.component';



@NgModule({
  declarations: [
    CommentLikeButtonComponent
  ],
  imports: [
    CommonModule
  ],
  exports : [
    CommentLikeButtonComponent
  ]
})
export class CommentLikeButtonModule { }
