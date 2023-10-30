import { Component, Input } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-detail-modal',
  templateUrl: './post-detail-modal.component.html',
  styleUrls: ['./post-detail-modal.component.scss']
})
export class PostDetailModalComponent {
  @Input() post? : PostResponse;
}
