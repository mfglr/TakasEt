
export const takeValueOfPosts = 10;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 10;
export const takeValueOfPostImages = 10;


export interface Page{
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
    page : { lastId : undefined, take : take },
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
      take : take,
    }
  }
}

export function removeOne(entityId : number,state : AppEntityState) : AppEntityState{
  let indexOfId = state.entityIds.findIndex(x => x == entityId);
  if(indexOfId != -1)
    return { ...state, entityIds : [...state.entityIds].splice(indexOfId,1) }
  return state;
}


