import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, filter, mergeMap } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImageUrlAction } from 'src/app/state/actions';
import { AppState } from 'src/app/state/reducer';
import { selectPostImage, selectPostImageLoadStatus, selectPostImageUrl } from 'src/app/state/selector';

@Component({
  selector: 'app-abstract-post',
  templateUrl: './abstract-post.component.html',
  styleUrls: ['./abstract-post.component.scss'],
})
export class AbstractPostComponent  implements OnInit {

  @Input() post? : PostResponse;
  @Input() postListUrl? : string;
  @Input() addIdToUrl = false;

  url$? : Observable<string | undefined>
  loadStatus$? : Observable<boolean | undefined>

  constructor(
    private appStore : Store<AppState>
  ) { }

  ngOnInit() {

    if(this.post){
      let firstImageId = this.post.postImages[0].id;
      this.appStore.dispatch(loadPostImageUrlAction({id : firstImageId}))

      this.url$ = this.appStore.select(selectPostImageUrl({id : firstImageId}));
      this.loadStatus$ = this.appStore.select(selectPostImageLoadStatus({id : firstImageId}))
    }

  }

}
