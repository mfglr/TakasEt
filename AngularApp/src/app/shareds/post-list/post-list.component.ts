import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @Input() posts? : PostResponse[] | undefined | null;
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;
  @Output() displayLikersEvent = new EventEmitter<PostResponse>();
  @Output() displayCommentsEvent = new EventEmitter<PostResponse>();
  @Output() displayViewersEvent = new EventEmitter<PostResponse>();
  @Output() setSelectedPostEvent = new EventEmitter<PostResponse>();
  @Output() displayPostEvent = new EventEmitter<PostResponse>();
  displayComments(post : PostResponse){
    this.displayCommentsEvent.emit(post);
  }

  displayPostLikers(post : PostResponse){
    this.displayLikersEvent.emit(post)
  }

  displayViewers(post : PostResponse){
    this.displayViewersEvent.emit(post);
  }

  displayPost(post : PostResponse){
    this.displayPostEvent.emit(post);
  }
  setSelectedPost(post : PostResponse){
    this.setSelectedPostEvent.emit(post);
  }
}
