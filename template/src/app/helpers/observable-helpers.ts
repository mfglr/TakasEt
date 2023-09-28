import { Observable, debounceTime, distinctUntilChanged, filter, map } from "rxjs";

export class ObservableHelpers{
  public static getImprovedPerformanceInput(input : Observable<string | null>) : Observable<string> {
    return input.pipe(
      debounceTime(300),
      filter(key => key != null && key.length > 2 ),
      map(key => key!.trim()),
      distinctUntilChanged(),
    )
  }
}
