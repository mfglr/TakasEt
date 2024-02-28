import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, first } from 'rxjs';
import { UserImageResponse } from 'src/app/models/responses/user-image-response';
import { UserImageEntityState } from 'src/app/shareds/profile-image/state/reducer';
import { selectState, selectUrl } from 'src/app/shareds/profile-image/state/selectors';
import { loadUserImageAction } from '../state/actions';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent {

  @Input() user? : UserResponse
  @Input() diameter : number = 2;

  style : string = `width:${this.diameter}rem;height:${this.diameter}rem;`;
  url$? : Observable<string | undefined>

  constructor(private readonly userImageStore : Store<UserImageEntityState>) { }

  ngOnChanges() {
    if(this.user && this.user.images.length > 0 ){

      this.userImageStore.dispatch(loadUserImageAction({
        id : this.user.images[0].id,
        containerName : this.user.images[0].containerName,
        blobName : this.user.images[0].blobName
      }));

      this.url$ = this.userImageStore.select(selectUrl({id : this.user.images[0].id}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
