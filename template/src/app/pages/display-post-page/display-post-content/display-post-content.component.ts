import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { BehaviorSubject, Observable, Subscription, filter, interval, map, mergeMap } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { AppHubConnectionService } from 'src/app/services/app-hub-connection.service';
import { ProfileImageService } from 'src/app/services/profile-image.service';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';
import { getLoginResponse } from 'src/app/states/user/selector';
import { UserState } from 'src/app/states/user/state';

@Component({
  selector: 'app-display-post-content',
  templateUrl: './display-post-content.component.html',
  styleUrls: ['./display-post-content.component.scss']
})
export class DisplayPostContentComponent {

  @Input() post : PostResponse | null = null;

  public counts? : {countOfLikes : number,countOfViews : number};
  private postSubject = new BehaviorSubject<PostResponse | undefined | null>(undefined);
  private source$ : Observable<PostResponse | undefined | null> = this.postSubject.pipe(
    filter(post => post != undefined && post != null)
  );

  public loginResponse$ = this.store.select(getLoginResponse)

  profileImage$? : Observable<string> = this.source$.pipe(
    mergeMap( () => this.profileImageService.getActiveProfileImage(this.post!.userId) )
  );

  private triggerGetCountOfLikesAndView : Subscription = this.source$.pipe(
    mergeMap(() => interval(5000)),
    map(() => this.appHubConnection.invoke<string>("SendCountOfViewsAndLikes",this.post!.id))
  ).subscribe();

  countsSubscription = this.source$.pipe(
    mergeMap(
      () => this.appHubConnection.on<{countOfLikes : number,countOfViews : number}>(
        "recieveCountOfViewsAndLikes",
        {  countOfLikes:0,countOfViews : 0}
      )
    )
  ).subscribe(x => this.counts = x);

  loggedInUserIsLiked$ = this.source$.pipe(
    mergeMap(() => this.likingService.IsLikedLoggedInUser(this.post!.id))
  )

  constructor(
    public likingService : UserPostLikingService,
    private profileImageService : ProfileImageService,
    private appHubConnection : AppHubConnectionService,
    private store : Store<UserState>
    ) {
    }

  ngOnChanges(){
    this.postSubject.next(this.post);
    if(this.post)this.appHubConnection.invoke<string>("SendCountOfViewsAndLikes",this.post!.id)
  }

  ngOnInit(): void {
    this.appHubConnection.create('post-hub');
    this.appHubConnection.start();
  }

  ngOnDestroy(): void {
    this.countsSubscription.unsubscribe();
    this.triggerGetCountOfLikesAndView?.unsubscribe();
    this.appHubConnection.stop();
    this.postSubject.complete();
  }
}
