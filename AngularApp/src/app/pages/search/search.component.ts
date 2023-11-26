import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { initSearchPageAction } from 'src/app/states/post-state/actions';
import { PagePostState, searchPagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  searchPagePostList = searchPagePostList
  posts$? : Observable<PostResponse[]>

  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}
  
  ngOnInit(){
    this.pagePostStore.dispatch(initSearchPageAction())
  }
  
}
