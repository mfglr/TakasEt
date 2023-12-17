import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, map, mergeMap } from 'rxjs';

@Component({
  selector: 'app-user-posts',
  templateUrl: './user-posts.page.html',
  styleUrls: ['./user-posts.page.scss'],
})
export class UserPostsPage implements OnInit {

  userId$? : Observable<number>;
  postsIds$? : Observable<number[]>;
  constructor(
    private activatedRoute : ActivatedRoute,

  ) { }

  ngOnInit() {
    this.userId$ = this.activatedRoute.paramMap.pipe(
      map(x => parseInt(x.get("userId")!))
    )

    // this.postsIds$ = this.userId$.pipe(
    //   mergeMap(userId => )
    // )

  }

}
