import { OperatorFunction, filter, first, map, pipe } from "rxjs";
import { AppEntityState } from "../state/app-entity-state/app-entity-state";

// export function filterAppEntityState() : OperatorFunction<AppEntityState | undefined,AppEntityState>{
//   return pipe(
//     filter(x => x != undefined),
//     first(),
//     filter(x => !(x!.isLastEntities)),
//     map(x => x!)
//   )
// }
