export interface Page{
  skip : number;
  take : number;
  lastId : number | undefined;
}

export interface AppEntityState{
  entityIds : number[];
  page : Page;
  isLastEntities : boolean;
}

export function init(take : number) : AppEntityState{
  return {
    entityIds : [],
    isLastEntities : false,
    page : { lastId : undefined, skip : 0, take : take }
  }
}
export function initWith(entityIds : number[],page : Page,isLastEntities : boolean) : AppEntityState{
  return {
    entityIds : [...entityIds],
    isLastEntities : isLastEntities,
    page : {...page}
  }
}
export function addOne(entityId : number,state : AppEntityState) : AppEntityState{
  return { ...state, entityIds : [entityId,...state.entityIds] }
}

export function addMany(entityIds : number[],take : number,state : AppEntityState) : AppEntityState{
  return {
    entityIds : [...state.entityIds,...entityIds],
    isLastEntities : entityIds.length < take,
    page : {
      lastId : entityIds.length > 0 ? entityIds[entityIds.length - 1] : state.page.lastId,
      skip : state.page.skip + take,
      take : take
    }
  }
}


