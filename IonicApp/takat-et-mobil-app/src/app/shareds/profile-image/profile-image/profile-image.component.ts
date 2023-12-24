import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadProfileImageUrlAction } from 'src/app/states/user-image-entity-state/actions';
import { UserImageEntityState } from 'src/app/states/user-image-entity-state/reducer';
import { selectLoadStatus, selectUrl } from 'src/app/states/user-image-entity-state/selectors';

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
    private userImageEntityStore : Store<UserImageEntityState>
  ) { }

  ngOnChanges() {
    if(this.id){
      this.userImageEntityStore.dispatch(loadProfileImageUrlAction({id : this.id}))
      this.loadStatus$ = this.userImageEntityStore.select(selectLoadStatus({ id : this.id}))
      this.url$ = this.userImageEntityStore.select(selectUrl({id : this.id}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
