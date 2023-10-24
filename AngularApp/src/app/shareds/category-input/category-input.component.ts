import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { from, map, mergeMap, toArray } from 'rxjs';
import { ObservableHelpers } from 'src/app/helpers/observable-helpers';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-input',
  templateUrl: './category-input.component.html',
  styleUrls: ['./category-input.component.scss']
})
export class CategoryInputComponent {

  categoryIdFormControl = new FormControl<string | null>(null);
  categoryNameFormControl = new FormControl<string | null>(null);
  @Output() categoryIdEvent = new EventEmitter<string>();

  namesOfCategories$ = ObservableHelpers.getImprovedPerformanceInput(this.categoryNameFormControl.valueChanges).pipe(
    mergeMap(
      (key) => this.categoryService.filerCategories(key).pipe(
        mergeMap(categories => from(categories)),
        map(category => ({name: category.name,id : category.id})),
        toArray()
      )
    )
  )

  constructor(private categoryService : CategoryService) {}

  setCategory(category : {name : string,id : string}){
    this.categoryNameFormControl.setValue(category.name);
    this.categoryIdFormControl.setValue(category.id);
    this.categoryIdEvent.emit(category.id);
  }

}
