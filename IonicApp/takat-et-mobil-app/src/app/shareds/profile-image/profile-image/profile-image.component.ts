import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserImageResponse } from 'src/app/models/responses/user-image-response';
import { UserResponse } from 'src/app/models/responses/user-response';
import { loadUserImageUrlAction } from 'src/app/state/actions';
import { AppState } from 'src/app/state/reducer';
import { selectUserImageLoadStatus, selectUserImageUrl } from 'src/app/state/selector';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent {

  @Input() userImage? : UserImageResponse
  @Input() diameter : number = 2;

  style? : string;
  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>

  constructor(
    private appStore : Store<AppState>
  ) { }

  ngOnChanges() {
    if(this.userImage ){
      this.appStore.dispatch(loadUserImageUrlAction({id : this.userImage.id}))
      this.loadStatus$ = this.appStore.select(selectUserImageLoadStatus({ id : this.userImage.id}))
      this.url$ = this.appStore.select(selectUserImageUrl({id : this.userImage.id}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
