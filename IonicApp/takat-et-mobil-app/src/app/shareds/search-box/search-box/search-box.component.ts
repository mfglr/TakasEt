import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { filterSearchInput } from 'src/app/custom-operators/filter-search-input';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.scss'],
})
export class SearchBoxComponent implements OnDestroy {

  @Output() keyChangesEvent = new EventEmitter<string>();
  inputControl = new FormControl<string>("");
  subs = this.inputControl.valueChanges.pipe(
    filterSearchInput()
  ).subscribe( key => this.keyChangesEvent.emit(key) )

  ngOnDestroy(): void { this.subs.unsubscribe(); }

}
