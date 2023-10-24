import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {

  posts$? : Observable<PostResponse[]>

  constructor(
    private postService : PostService
  ) {}

}
