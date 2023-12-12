import { Observable, debounceTime, distinctUntilChanged, filter, from, map, mergeMap, toArray } from "rxjs";

export class ObservableHelpers{

  static getImprovedPerformanceInput(input : Observable<string | null>) : Observable<string> {
    return input.pipe(
      debounceTime(300),
      filter(key => key != null && key.length > 2 ),
      map(key => key!.trim()),
      distinctUntilChanged(),
    )
  }

}
