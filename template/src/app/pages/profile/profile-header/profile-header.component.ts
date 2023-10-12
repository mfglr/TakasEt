import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { UserFollowingService } from 'src/app/services/user-following.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.scss']
})
export class ProfileHeaderComponent implements OnChanges {

  @Input() userId : string | null = null;

  constructor(
    private userService : UserService,
    public followingService : UserFollowingService
  ) {}

  user? : UserResponse
  userSubsctiption? : Subscription

  ngOnChanges(changes: SimpleChanges): void {
    if(this.userId){
      this.userSubsctiption = this.userService.getUser(this.userId).subscribe( x => this.user = x);
    }
  }
  getValue(value : number){
    if(this.user)
      this.user.countOfFollowers += value;
  }

  ngOnDestroy(): void {
    this.userSubsctiption?.unsubscribe();
  }
}
