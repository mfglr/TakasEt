import { EntityState } from "@ngrx/entity";

export const takeValueOfPosts = 3;
export const takeValueOfComments = 2;
export const takeValueOfUsers = 10;

export const initialPageOfPosts = { skip : 0, take : takeValueOfPosts,firstQueryDate : Date.now() }
export const initialPageOfComments = { skip : 0, take : takeValueOfComments,firstQueryDate : Date.now() }
export const initialPageOfUsers = { skip : 0, take : takeValueOfUsers,firstQueryDate : Date.now() }

export interface Page{
  skip : number;
  take : number;
  firstQueryDate : number;
}

export interface AppState<T> extends EntityState<T>{
  selectedId : string | undefined,
  status : boolean;
  page : Page;
}

