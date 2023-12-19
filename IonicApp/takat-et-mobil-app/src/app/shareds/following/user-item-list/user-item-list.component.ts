import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-item-list',
  templateUrl: './user-item-list.component.html',
  styleUrls: ['./user-item-list.component.scss'],
})
export class UserItemListComponent{

  @Input() userIds? : number[] | null


  constructor() { }

  ngOnChanges(){
  }

}
