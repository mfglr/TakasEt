import { Component, ElementRef, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as appPostActions from 'src/app/states/post_state/actions';
import { AppPostState, postsOfHomePageQueryId } from 'src/app/states/post_state/state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;
  @ViewChild("usersListModalButton",{static : true}) usersListModalButton? : ElementRef;
  @ViewChild("displayPostModalButton",{static : true}) displayPostModalButton? : ElementRef;

  postsOfHomePageQueryId = postsOfHomePageQueryId;

  constructor(
    private store : Store<AppPostState>
  ) {}


  ngOnInit(){
    this.store.dispatch(appPostActions.setSelectedQueryId({queryId : this.postsOfHomePageQueryId}))
  }

  displayComments(post : PostResponse){
    if(this.commentModalButton) {
      this.commentModalButton.nativeElement.click();
    }
  }
}
