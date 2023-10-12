import { Component, OnChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ObservableHelpers } from 'src/app/helpers/observable-helpers';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageService } from 'src/app/services/post-image.service';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnChanges {
  data$? : Observable<{x : PostResponse,y:string}[]>
  public userId : string | null = null;

  constructor(
    private postImageService : PostImageService,
    private postService : PostService,
    private activatedRoute : ActivatedRoute
    ) {

  }
  ngOnInit(){
    this.userId = this.activatedRoute.snapshot.paramMap.get('id');
    if(this.userId)
      this.data$ = ObservableHelpers.mergeArrays(
        this.postService.getPostsByUserName(this.userId),
        this.postImageService.getFirsImageOfPostsByUserName(this.userId)
      )
  }
  ngOnChanges(){

  }

}
