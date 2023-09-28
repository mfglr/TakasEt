import { Component, OnInit } from '@angular/core';
import { CategoryService } from './services/category.service';
import { UserState } from './states/user/state';
import { Store } from '@ngrx/store';
import { isLogin } from './states/user/selector';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Template';

  islogin$ = this.store.select(isLogin);


  constructor(
    private store : Store<UserState>) {
    }

  ngOnInit(): void {

  }



}
