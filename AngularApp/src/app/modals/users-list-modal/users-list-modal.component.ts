import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { UserResponse } from 'src/app/models/responses/user-response';
import { nextPageOfPostLikers } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';

@Component({
  selector: 'app-users-list-modal',
  templateUrl: './users-list-modal.component.html',
  styleUrls: ['./users-list-modal.component.scss']
})
export class UsersListModalComponent {
  @Input() users? : UserResponse[] | null;
  @Output() nextPageOfPostLikersEvent = new EventEmitter<void>()

  getNextPageOfPostLikers(){
    this.nextPageOfPostLikersEvent.emit();
  }
}
