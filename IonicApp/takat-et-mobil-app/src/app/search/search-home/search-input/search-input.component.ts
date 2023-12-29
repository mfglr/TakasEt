import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { filterSearchInput } from 'src/app/custom-operators/filter-search-input';
import { SearchHomePageState } from '../state/reducer';
import { searchPostsAction } from '../state/action';

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss'],
})
export class SearchInputComponent  implements OnInit {

  inputControl = new FormControl<string>("");

  constructor(
    private router : Router,
    private searchHomePageStore : Store<SearchHomePageState>
  ) { }

  ngOnInit() {
    this.inputControl.valueChanges.pipe(
      filterSearchInput()
    ).subscribe(
      key => this.searchHomePageStore.dispatch(searchPostsAction({key : key}))
    )
  }

  navigateFilterPage(){
    this.router.navigate(['/place/search/filter'])
  }

}
