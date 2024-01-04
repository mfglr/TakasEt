import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchRoutingModule } from './search-routing-module';
import { UsersListModule } from '../shareds/users-list/users-list.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SearchRoutingModule,
  ]
})
export class SearchModule { }
