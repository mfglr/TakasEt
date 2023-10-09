import { Component } from '@angular/core';
import { UserState } from './states/user/state';
import { Store } from '@ngrx/store';
import { isLogin } from './states/user/selector';
import { PostService } from './services/post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  urls : string[] = [
    "https://images.pexels.com/photos/771742/pexels-photo-771742.jpeg?auto=compress&cs=tinysrgb&w=600",
    "https://media-cdn.tripadvisor.com/media/photo-s/1d/8a/28/fc/dr.jpg"
  ]


  imageUrl : string =  "https://media-cdn.tripadvisor.com/media/photo-s/1d/8a/28/fc/dr.jpg"
  private postId = "16aa2259-44a1-4aaf-a070-df3c1e998e9d";
  isLogin$ = this.store.select(isLogin)

  post$ = this.postService.getById(this.postId);

  constructor(
    private store : Store<UserState>,
    private postService : PostService
    ) {
    }

    ngOnInit(){
    }
}
