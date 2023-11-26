import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { initHomePageAction } from 'src/app/states/post-state/actions';
import { PagePostState } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  
  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}

  ngOnInit(){
    this.pagePostStore.dispatch(initHomePageAction())
  }
}
