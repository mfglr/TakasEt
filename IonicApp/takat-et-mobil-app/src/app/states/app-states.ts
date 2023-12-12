import { EntityState } from "@ngrx/entity";

export const takeValueOfPosts = 10;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 10;
export const takeValueOfPostImages = 10;


export interface ImageState {
  id : number;
  loadStatus : boolean;
  url : string | undefined;
}


