import { AfterViewChecked, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostImageResponse } from 'src/app/models/responses/post-image-response';
import { PostResponse } from 'src/app/models/responses/post-response';
import { AppState } from 'src/app/state/reducer';
import { selectPostImageLoadStatus, selectPostImageUrl } from 'src/app/state/selector';

@Component({
  selector: 'app-post-image-slider-item',
  templateUrl: './post-image-slider-item.component.html',
  styleUrls: ['./post-image-slider-item.component.scss'],
})
export class PostImageSliderItemComponent  implements OnInit,AfterViewChecked {

  @Input() post? : PostResponse | null;
  @Input() postImage? : PostImageResponse;
  @ViewChild("loading",{static : false}) loading? : ElementRef;

  heightOfLoading : number = 5;
  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>

  constructor(
    private appStore: Store<AppState>
  ) { }

  ngOnInit() {
    if(this.postImage){
      this.loadStatus$ = this.appStore.select(selectPostImageLoadStatus({id : this.postImage.id}))
      this.url$ = this.appStore.select(selectPostImageUrl({id : this.postImage.id}))
    }
  }

  ngAfterViewChecked(): void {
    if(this.loading && this.postImage){
      this.heightOfLoading = this.postImage.aspectRatio * this.loading.nativeElement.clientWidth
    }
  }




}
