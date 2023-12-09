import { EntityState } from "@ngrx/entity";

export const takeValueOfPosts = 10;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 10;
export const takeValueOfPostImages = 10;

export interface Page{
  skip : number;
  take : number;
  lastId : number | undefined;
}

export interface ImageState {
  id : number;
  loadStatus : boolean;
  url : string | undefined;
}

export interface AppEntityState<T> extends EntityState<T> {
  page : Page;
  status : boolean;
}