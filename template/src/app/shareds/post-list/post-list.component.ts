import { Component, Input, OnDestroy } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @Input() posts? : PostResponse[] | undefined | null;
}
