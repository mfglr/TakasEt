import { createEntityAdapter } from "@ngrx/entity";
import { BaseResponse } from "src/app/models/responses/base-response";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";
import { AppEntityState, takeValueOfPosts, takeValueOfUsers } from "./app-entity-state";

class AppEntityAdapter<T extends BaseResponse>{

  private adapter;
  private take : number;

  constructor(take : number) {
    this.adapter = createEntityAdapter<T>();
    this.take = take
  }

  private _selectResponses = (state : AppEntityState<T>) => this.adapter.getSelectors().selectAll(state.entities)
  public get selectResponses(){ return this._selectResponses; }

  init() : AppEntityState<T>{
    return {
      entities : this.adapter.getInitialState(),
      isLastEntities : false,
      page : { lastId : undefined, take : this.take }
    }
  }

  addMany(entities : T[],state : AppEntityState<T>) : AppEntityState<T>{
    return {
      entities : this.adapter.addMany(entities,state.entities),
      isLastEntities : entities.length < this.take,
      page : {
        lastId : entities.length > 0 ? entities[entities.length - 1].id : state.page.lastId,
        take : this.take
      }
    }
  }

}

export const appPostAdapter = new AppEntityAdapter<PostResponse>(takeValueOfPosts)
export const appUserAdapter = new AppEntityAdapter<UserResponse>(takeValueOfUsers)
