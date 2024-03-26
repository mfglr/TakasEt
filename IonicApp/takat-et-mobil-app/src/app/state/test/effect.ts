import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { filter, from, map, mergeMap, of } from "rxjs";
import { subscribeAction, removeAction, addAction } from "./actions";
import { TestState } from "./reducer";
import { Store } from "@ngrx/store";
import { selectData } from "./selectors";

@Injectable()
export class TestEffect{

  constructor(
    private readonly actions : Actions,
    private readonly store : Store<TestState>
  ) {

  }

  increase$ = createEffect(
    () => this.actions.pipe(
      ofType(subscribeAction),
      mergeMap(() => this.store.select(selectData)),
      filter(values => values.length > 0),
      mergeMap(values => of(removeAction({id : values[0]}))),
    )
  )
}
