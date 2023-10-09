import { Component, Input, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Observable, Subscription} from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageService } from 'src/app/services/post-image.service';
import { UserPostViewingService } from 'src/app/services/user-post-viewing.service';

@Component({
  selector: 'app-display-post',
  templateUrl: './display-post.component.html',
  styleUrls: ['./display-post.component.scss']
})
export class DisplayPostComponent implements OnChanges,OnDestroy{

  @Input() post : PostResponse | null = null;
  private viewPostSubscription? : Subscription
  urls$? : Observable<string[]>;

  constructor(
    private postImageService : PostImageService,
    private viewingService : UserPostViewingService
    ) {
    }

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post){
      this.urls$ = this.postImageService.getPostImagesByPostId(this.post.id);
      this.viewPostSubscription = this.viewingService.viewPost(this.post.id).subscribe();
    }
  }

  ngOnDestroy(): void {
    this.viewPostSubscription?.unsubscribe();
  }
}
