import { Component } from '@angular/core';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {

  posts$ = this.postService.getPostsWithFirstImages()

  constructor(
    private postService : PostService
  ) {}

}
