import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { AppState } from 'src/app/states/reducer';
import { selectPostImageLoadStatus, selectPostImageUrl } from 'src/app/states/selector';

@Component({
  selector: 'app-post-image-slider-item',
  templateUrl: './post-image-slider-item.component.html',
  styleUrls: ['./post-image-slider-item.component.scss'],
})
export class PostImageSliderItemComponent  implements OnInit {

  @Input() post? : PostResponse | null;
  @Input() id? : number;

  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>

  constructor(
    private appStore: Store<AppState>
  ) { }

  ngOnInit() {
    if(this.id){
      this.loadStatus$ = this.appStore.select(selectPostImageLoadStatus({id : this.id}))
      this.url$ = this.appStore.select(selectPostImageUrl({id : this.id}))
    }
  }

}
