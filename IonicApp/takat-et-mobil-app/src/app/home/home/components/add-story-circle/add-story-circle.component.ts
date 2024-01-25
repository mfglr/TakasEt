import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter, first, mergeMap } from 'rxjs';
import { PhotoService } from 'src/app/services/photo.service';
import { loadUserImageUrlAction } from 'src/app/states/actions';
import { AppState } from 'src/app/states/reducer';
import { selectUser, selectUserImageLoadStatus, selectUserImageUrl } from 'src/app/states/selector';

@Component({
  selector: 'app-add-story-circle',
  templateUrl: './add-story-circle.component.html',
  styleUrls: ['./add-story-circle.component.scss'],
})
export class AddStoryCircleComponent  implements OnInit {

  constructor(
    private appStore : Store<AppState>,
    private photeService : PhotoService,
    private router : Router
  ) { }

  user$ = this.appStore.select(selectUser)
  profileImageLoadStatus$ = this.user$.pipe(
    filter(user => user != undefined && user.userImage != undefined),
    mergeMap(user => this.appStore.select(selectUserImageLoadStatus({id : user!.userImage!.id})))
  )
  profileImage$ = this.user$.pipe(
    filter(user => user != undefined && user.userImage != undefined),
    mergeMap(user => this.appStore.select(selectUserImageUrl({id : user!.userImage!.id})))
  )

  ngOnInit() {
    this.user$.pipe(
      filter(user => user != undefined),
      first(),
      filter(user => user?.userImage != undefined),
    ).subscribe(
      user => {
        this.appStore.dispatch(loadUserImageUrlAction({id : user!.userImage!.id}))
      }
    )
  }

  navigateCreateStoryPage(){
    this.router.navigate(["/place/home/create-story"]);
  }

}
