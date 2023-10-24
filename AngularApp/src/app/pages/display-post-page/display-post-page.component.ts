import { Component, Input, SimpleChanges } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageService } from 'src/app/services/post-image.service';
import { PostService } from 'src/app/services/post.service';
import { UserPostViewingService } from 'src/app/services/user-post-viewing.service';

@Component({
  selector: 'app-display-post-page',
  templateUrl: './display-post-page.component.html',
  styleUrls: ['./display-post-page.component.scss']
})
export class DisplayPostPageComponent {

  private viewPostSubscription? : Subscription
  urls$? : Observable<string[]>;
  @Input() post? : PostResponse;

  constructor(
    private postImageService : PostImageService,
    private viewingService : UserPostViewingService,
    ) {
    }

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post){
      this.urls$ = this.postImageService.getPostImages(this.post.id);
      this.viewPostSubscription = this.viewingService.viewPost(this.post.id).subscribe();
    }
  }

  ngOnDestroy(): void {
    this.viewPostSubscription?.unsubscribe();
  }
}
