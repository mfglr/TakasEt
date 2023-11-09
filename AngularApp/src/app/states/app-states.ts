import { EntityState } from "@ngrx/entity";

export const takeValueOfPosts = 10;
export const takeValueOfComments = 1;
export const takeValueOfUsers = 1;
export const takeValueOfPostImages = 1;

export const initialPageOfPosts = { skip : 0, take : takeValueOfPosts,firstQueryDate : Date.now() }
export const initialPageOfComments = { skip : 0, take : takeValueOfComments,firstQueryDate : Date.now() }
export const initialPageOfUsers = { skip : 0, take : takeValueOfUsers,firstQueryDate : Date.now() }
export const initialPageOfPostImages = { skip : 0, take : takeValueOfPostImages,firstQueryDate : Date.now() }

export interface Page{
  skip : number;
  take : number;
  firstQueryDate : number;
}
export interface AppEntityState<T> extends EntityState<T>{ page : Page; status : boolean;}





