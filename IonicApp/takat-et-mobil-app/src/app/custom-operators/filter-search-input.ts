import { OperatorFunction, debounceTime, distinctUntilChanged, filter, map, pipe } from "rxjs";

export function filterSearchInput() : OperatorFunction<string | null,string> {
  return pipe(
    debounceTime(300),
    filter(key => key != null && key.length > 2 ),
    map(key => key!.trim()),
    distinctUntilChanged(),
  )
}
