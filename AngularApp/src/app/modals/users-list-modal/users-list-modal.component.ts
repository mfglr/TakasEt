import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserResponse } from 'src/app/models/responses/user-response';

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
