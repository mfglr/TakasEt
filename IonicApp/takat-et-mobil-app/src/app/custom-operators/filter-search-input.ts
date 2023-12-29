import { OperatorFunction, debounceTime, distinctUntilChanged, filter, map, pipe } from "rxjs";

export function filterSearchInput() : OperatorFunction<string | null,string> {
  return pipe(
    debounceTime(300),
    filter(key => key != null),
    map(key => key!.trim()),
    distinctUntilChanged(),
  )
}
