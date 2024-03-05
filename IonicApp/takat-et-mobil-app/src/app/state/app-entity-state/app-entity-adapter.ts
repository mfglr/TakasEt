import { Comparer, Update, createEntityAdapter } from "@ngrx/entity";
import { AppEntityState, Pagination, Page} from "./app-entity-state";
import { BaseResponse } from "src/app/models/responses/base-response";

export class AppEntityAdapter<E extends BaseResponse,T extends Pagination<E>>{

  private adapter;
  private take : number;
  private isDescending : boolean

  constructor(take : number,sortComparer : Comparer<T> | undefined = undefined,isDescending : boolean = true) {
      this.adapter = createEntityAdapter<T>({
        selectId : state => state.entity.id,
        sortComparer : sortComparer
      });
    this.take = take
    this.isDescending = isDescending;
  }

  private _selectResponses = (state : AppEntityState<E,T>) =>
    this.adapter
      .getSelectors()
      .selectAll(state.entities)
      .map(x=>x.entity)

  public get selectResponses(){ return this._selectResponses; }

  private setLastValue = (entities : T[],page : Page) : Page => ({
    ...page,
    lastValue : entities.length > 0 ? entities[entities.length - 1].paginationProperty : page.lastValue
  });

  init() : AppEntityState<E,T>{
    return {
      entities : this.adapter.getInitialState(),
      isLast : false,
      page : { lastValue : undefined, take : this.take,isDescending : this.isDescending },
    }
  }

  nextPage(entities : T[],state : AppEntityState<E,T>) : AppEntityState<E,T>{
    return {
      ...state,
      entities : this.adapter.addMany(entities,state.entities),
      isLast : entities.length < this.take,
      page : this.setLastValue(entities,state.page)
    }
  }

  addOne(entity: T,state : AppEntityState<E,T>) : AppEntityState<E,T>{
    return { ...state, entities : this.adapter.addOne(entity,state.entities) }
  }

  updateOne(entity : Update<T>,state : AppEntityState<E,T>) : AppEntityState<E,T>{
    return {...state,entities : this.adapter.updateOne(entity,state.entities)}
  }
}

