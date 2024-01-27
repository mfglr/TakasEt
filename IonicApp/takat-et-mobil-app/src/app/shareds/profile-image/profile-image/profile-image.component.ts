import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadUserImageUrlAction } from 'src/app/state/actions';
import { AppState } from 'src/app/state/reducer';
import { selectUserImageLoadStatus, selectUserImageUrl } from 'src/app/state/selector';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent {

  @Input() userImageId? : number;
  @Input() userName : string='takaset.com';
  @Input() diameter : number = 2;

  style? : string;
  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>

  constructor(
    private appStore : Store<AppState>
  ) { }

  ngOnChanges() {
    if(this.userImageId){
      this.appStore.dispatch(loadUserImageUrlAction({id : this.userImageId}))
      this.loadStatus$ = this.appStore.select(selectUserImageLoadStatus({ id : this.userImageId}))
      this.url$ = this.appStore.select(selectUserImageUrl({id : this.userImageId}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
