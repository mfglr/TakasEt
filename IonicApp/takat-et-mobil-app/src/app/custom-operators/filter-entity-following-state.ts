import { OperatorFunction, filter, first, map, pipe } from "rxjs";
import { FollowingState } from "../states/following-state/reducer";

export function filterEntityFollowingState() : OperatorFunction<FollowingState | undefined,FollowingState>{
  return pipe(
    filter(state => state != undefined),
    first(),
    map(state=> state!)
  )
}
