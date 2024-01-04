import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { nextCategoriesAction } from 'src/app/states/category-entity-state/actions';
import { CategoryEntityState } from 'src/app/states/category-entity-state/reducer';
import { selectCategories } from 'src/app/states/category-entity-state/selectors';

@Component({
  selector: 'app-category-selector',
  templateUrl: './category-selector.component.html',
  styleUrls: ['./category-selector.component.scss'],
})
export class CategorySelectorComponent implements OnInit {


  categories$ = this.categoryEntityStore.select(selectCategories);

  constructor(
    private categoryEntityStore : Store<CategoryEntityState>
  ) {}

  ngOnInit() {
    this.categoryEntityStore.dispatch(nextCategoriesAction());
  }

  onChange(e : any){
    console.log(e);
  }
}
