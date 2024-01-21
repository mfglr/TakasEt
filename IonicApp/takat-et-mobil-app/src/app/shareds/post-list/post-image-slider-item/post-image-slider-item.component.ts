import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageState } from 'src/app/states/post-image-state/reducer';
import { selectLoadStatus, selectUrl } from 'src/app/states/post-image-state/selectors';

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
    private postImageStore: Store<PostImageState>
  ) { }

  ngOnInit() {
    if(this.id){
      this.loadStatus$ = this.postImageStore.select(selectLoadStatus({id : this.id}))
      this.url$ = this.postImageStore.select(selectUrl({id : this.id}))
    }
  }

}
