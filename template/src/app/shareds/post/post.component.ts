import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { HomeState } from 'src/app/states/home/states';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnChanges {

  @Input() post? : PostResponse;
  @Output() commentButtonEvent = new EventEmitter<PostResponse>();
  firstImage? : string;

  constructor(
    private store : Store<HomeState>
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post) this.firstImage = this.post.images[0];
  }

  transitCommentButtonEvent(post : PostResponse){
    this.commentButtonEvent.emit(post);
  }
}
