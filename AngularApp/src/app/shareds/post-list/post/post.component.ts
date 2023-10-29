import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnChanges {

  @Input() post? : PostResponse;
  @Output() displayComentsEvent = new EventEmitter<PostResponse>();
  @Output() displayPostLikersEvent = new EventEmitter<PostResponse>();
  @Output() displayViewersEvent = new EventEmitter<PostResponse>();
  @Output() setSelectedPostEvent = new EventEmitter<PostResponse>();

  firstImage? : string;

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post) this.firstImage = this.post.images[0];
  }

  displayComments(post : PostResponse){
    this.displayComentsEvent.emit(post);
  }

  displayPostLikers(post : PostResponse){
    this.displayPostLikersEvent.emit(post)
  }

  displayViewers(post : PostResponse){
    this.displayViewersEvent.emit(post)
  }

  setSelectedPost(){
    if(this.post) this.setSelectedPostEvent.emit(this.post)
  }

}
