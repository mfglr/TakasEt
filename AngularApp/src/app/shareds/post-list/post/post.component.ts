import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnChanges {
  @Input() post? : PostResponse;
  @Output() diplayCommentsEvent = new EventEmitter<PostResponse>();

  firstImage? : string;

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post) this.firstImage = this.post.firtImage
  }

  displayComments(post : PostResponse){
    if(this.post)
      this.diplayCommentsEvent.emit(this.post)
  }
}