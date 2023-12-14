import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-abstract-post-list',
  templateUrl: './abstract-post-list.component.html',
  styleUrls: ['./abstract-post-list.component.scss'],
})
export class AbstractPostListComponent  implements OnInit {
  @Input() postIds? : number[] | null;
  @Input() url? : string;
  constructor() { }

  ngOnInit() {}

}
