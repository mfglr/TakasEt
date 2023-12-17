import { OperatorFunction, filter, first, map, pipe } from "rxjs";
import { UserState } from "../states/user-entity-state/reducer";

export function filterUserState() : OperatorFunction<UserState | undefined,UserState | undefined>{
  return pipe(
    first(),
    filter(x => x == undefined || !(x.loadStatus)),
  )
}
