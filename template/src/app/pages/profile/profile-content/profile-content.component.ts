import { Component } from '@angular/core';
import { PostImageService } from 'src/app/services/post-image.service';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-profile-content',
  templateUrl: './profile-content.component.html',
  styleUrls: ['./profile-content.component.scss']
})
export class ProfileContentComponent {


  constructor(
    private postImageService : PostImageService,
    private postService : PostService
  ) {

  }
}
