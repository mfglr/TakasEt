import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadUserImageUrlAction } from 'src/app/states/user-image-entity-state/actions';
import { UserImageEntityState } from 'src/app/states/user-image-entity-state/reducer';
import { selectLoadStatus, selectUrl } from 'src/app/states/user-image-entity-state/selectors';

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
    private userImageEntityStore : Store<UserImageEntityState>
  ) { }

  ngOnChanges() {
    if(this.userImageId){
      this.userImageEntityStore.dispatch(loadUserImageUrlAction({id : this.userImageId}))
      this.loadStatus$ = this.userImageEntityStore.select(selectLoadStatus({ id : this.userImageId}))
      this.url$ = this.userImageEntityStore.select(selectUrl({id : this.userImageId}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
