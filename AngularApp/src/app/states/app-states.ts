import { EntityState } from "@ngrx/entity";

export const takeValueOfPosts = 5;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 1;
export const takeValueOfPostImages = 1;

function createPage(take : number) : Page{
  let date = new Date();
  return {
    skip : 0,
    take : take,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds()
  }
}

export const initialPageOfPosts : Page = { ...createPage(takeValueOfPosts) }
export const initialPageOfComments : Page= { ...createPage(takeValueOfComments) }
export const initialPageOfUsers : Page = { ...createPage(takeValueOfUsers) }
export const initialPageOfPostImages : Page = { ...createPage(takeValueOfPostImages) }

export interface Page{
  skip : number;
  take : number;
  year : number;
  month : number;
  day : number;
  hour : number;
  minute : number;
  second : number;
  milisecond : number;
}
export interface AppEntityState<T> extends EntityState<T>{ page : Page; status : boolean;}





