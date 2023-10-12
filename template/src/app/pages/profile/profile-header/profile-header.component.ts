import { Component, ElementRef, Input, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { FollowingService } from 'src/app/services/following.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.scss']
})
export class ProfileHeaderComponent implements OnChanges {

  @Input() userName : string | null = null;
  @ViewChild("followButton",{static : true}) followButton : ElementRef | null = null;

  constructor(
    private userService : UserService,
    private followingService : FollowingService
  ) {}

  user? : UserResponse
  userSubsctiption? : Subscription

  ngOnChanges(changes: SimpleChanges): void {
    if(this.userName){
      this.userSubsctiption = this.userService.getUserByUserName(this.userName).subscribe( x => this.user = x);
    }
  }

  ngOnDestroy(): void {
    this.userSubsctiption?.unsubscribe();
  }
}
