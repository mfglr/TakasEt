import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { IonSelect } from '@ionic/angular';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-category-selector',
  templateUrl: './category-selector.component.html',
  styleUrls: ['./category-selector.component.scss'],
})
export class CategorySelectorComponent implements OnInit {

  @Output() changeCategoryIdEvent = new EventEmitter<string | undefined>();

  // categories$ = this.categoryEntityStore.select(selectCategories);

  constructor(
    // private categoryEntityStore : Store<CategoryEntityState>
  ) {}

  ngOnInit() {
    // this.categoryEntityStore.dispatch(nextCategoriesAction());
  }

  ngOnChanges(){
  }

  onChange(e : any){
    let ids = (e.detail.value as number[]);
    if(ids.length <= 0)
      this.changeCategoryIdEvent.emit(undefined);
    else
      this.changeCategoryIdEvent.emit(
        ids.map(x => `${x}`).reduce((prev,current) => `${prev},${current}`)
      )
  }
}
