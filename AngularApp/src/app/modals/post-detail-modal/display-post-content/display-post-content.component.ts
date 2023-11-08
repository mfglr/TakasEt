import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { BehaviorSubject, Observable, Subscription, filter, interval, map, mergeMap } from 'rxjs';
import { Counts } from 'src/app/models/hub/counts';
import { PostResponse } from 'src/app/models/responses/post-response';
import { AppHubConnectionService } from 'src/app/services/app-hub-connection.service';
import { ProfileImageService } from 'src/app/services/profile-image.service';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';
import { AppLoginState } from 'src/app/states/login_state/state';

@Component({
  selector: 'app-display-post-content',
  templateUrl: './display-post-content.component.html',
  styleUrls: ['./display-post-content.component.scss']
})
export class DisplayPostContentComponent {

  @Input() post : PostResponse | null | undefined = null;

  public counts? : Counts;
  private postSubject = new BehaviorSubject<PostResponse | undefined | null>(undefined);
  private source$ : Observable<PostResponse | undefined | null> = this.postSubject.pipe(
    filter(post => post != undefined && post != null)
  );

  profileImage$? : Observable<string> = this.source$.pipe(
    mergeMap( () => this.profileImageService.getActiveProfileImage(this.post!.userId) )
  );

  private triggerGetCountOfLikesAndView : Subscription = this.source$.pipe(
    mergeMap(() => interval(5000)),
    map(() => this.appHubConnection.invoke<string>("SendCountOfViewsAndLikes",this.post!.id))
  ).subscribe();

  countsSubscription = this.source$.pipe(
    mergeMap(
      () => this.appHubConnection.on<Counts>(
        "recieveCountOfViewsAndLikes",
        {  countOfLikes:0,countOfViews : 0,countOfComments : 0}
      )
    )
  ).subscribe(x => this.counts = x);

  constructor(
    public likingService : UserPostLikingService,
    private profileImageService : ProfileImageService,
    private appHubConnection : AppHubConnectionService,
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
