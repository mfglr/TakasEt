import { Component, Input } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-abstract-post-list',
  templateUrl: './abstract-post-list.component.html',
  styleUrls: ['./abstract-post-list.component.scss'],
})
export class AbstractPostListComponent {
  @Input() posts? : PostResponse[] | null;
  @Input() postListUrl? : string;
  @Input() addIdToUrl = false;
  @Input() size : 3 | 4 | 6 = 3;
  @Input() isLastEntities : boolean = false;
}
