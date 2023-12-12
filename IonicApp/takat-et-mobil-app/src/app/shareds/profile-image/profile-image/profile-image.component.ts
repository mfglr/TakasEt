import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadProfileImageUrlAction } from 'src/app/states/profile-image-state/actions';
import { ProfileImageState } from 'src/app/states/profile-image-state/reducer';
import { selectLoadStatus, selectUrl } from 'src/app/states/profile-image-state/selectors';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent {

  @Input() id? : number;
  @Input() userName : string='takaset.com';
  @Input() diameter : number = 2;

  style? : string;
  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>

  constructor(
    private profileImageStore : Store<ProfileImageState>
  ) { }

  ngOnChanges() {
    if(this.id){
      this.profileImageStore.dispatch(loadProfileImageUrlAction({id : this.id}))
      this.loadStatus$ = this.profileImageStore.select(selectLoadStatus({ id : this.id}))
      this.url$ = this.profileImageStore.select(selectUrl({id : this.id}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
