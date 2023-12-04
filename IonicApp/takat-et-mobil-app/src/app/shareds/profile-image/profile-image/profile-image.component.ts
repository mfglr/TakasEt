import { Component, Input, OnInit } from '@angular/core';
import { ProfileImageState } from '../state/reducer';
import { Store } from '@ngrx/store';
import { loadProfileImageAction } from '../state/actions';
import { Observable } from 'rxjs';
import { selectLoadStatus,selectUrl } from '../state/selectors';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent implements OnInit {
  
  @Input() id? : number;
  @Input() userName : string='takaset.com';
  @Input() diameter : number = 2;

  style? : string;
  loadStatus$? : Observable<boolean | undefined>
  url$? : Observable<string | undefined>
  
  constructor(
    private profileImageStore : Store<ProfileImageState>
  ) { }
  
  ngOnInit() {
    if(this.id){
      this.profileImageStore.dispatch(loadProfileImageAction({id : this.id!}))
      this.loadStatus$ = this.profileImageStore.select(selectLoadStatus({ id : this.id}))    
      this.url$ = this.profileImageStore.select(selectUrl({id : this.id}))
    }
    this.style = `width:${this.diameter}rem;height:${this.diameter}rem;`
  }

}
