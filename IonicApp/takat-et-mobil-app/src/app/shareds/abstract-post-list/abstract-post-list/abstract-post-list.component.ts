import { Component, ElementRef, EventEmitter, Input, OnInit, Output, QueryList, ViewChild, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-abstract-post-list',
  templateUrl: './abstract-post-list.component.html',
  styleUrls: ['./abstract-post-list.component.scss'],
})
export class AbstractPostListComponent  implements OnInit {

  @Input() postIds? : number[] | null;
  @Input() postListUrl? : string;
  @Input() addIdToUrl = false;
  @Input() size : 3 | 4 | 6 = 3;

  height ?: number;
  constructor() { }

  ngOnInit() {}

}
