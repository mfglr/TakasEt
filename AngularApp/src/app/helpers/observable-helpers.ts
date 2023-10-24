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

  static mergeArrays<X,Y>(x : Observable<X[]>,y : Observable<Y[]>) : Observable<{x : X,y : Y}[]>{
    return x.pipe(
      mergeMap( xs => y.pipe(
        mergeMap(ys => from(xs).pipe(
          map((x,index) => ({x:x,y : ys[index]})),
          toArray()
        )),
      ))
    )
  }
}
