import { Component, ElementRef, Input, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { NoContentResponse } from 'src/app/models/responses/no-content-response';
import { UserResponse } from 'src/app/models/responses/user-response';
import { FollowingService } from 'src/app/services/following.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.scss']
})
export class ProfileHeaderComponent implements OnChanges {

  @Input() userId : string | null = null;
  @ViewChild("followingButton",{static : true}) followingButton : ElementRef | null = null;


  constructor(
    private userService : UserService,
    private followingService : FollowingService
  ) {}
  isFollowed$? : Observable<NoContentResponse>;

  user? : UserResponse
  userSubsctiption? : Subscription

  ngOnChanges(changes: SimpleChanges): void {
    if(this.userId){
      this.userSubsctiption = this.userService.getUser(this.userId).subscribe( x => this.user = x);
      this.isFollowed$ = this.followingService.isFollowed(this.userId);
    }
  }

  ngOnDestroy(): void {
    this.userSubsctiption?.unsubscribe();
  }
}
