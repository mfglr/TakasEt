import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { initHomePageAction } from 'src/app/states/post-state/actions';
import { PagePostState } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(
    private pagePostStore : Store<PagePostState>
  ) { }

  ngOnInit() {
    this.pagePostStore.dispatch(initHomePageAction())
  }

}
