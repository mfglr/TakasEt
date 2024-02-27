import { EntityState } from "@ngrx/entity";
import { BaseResponse } from "../../models/responses/base-response";

export const takeValueOfPosts = 15;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 10;
export const takeValueOfPostImages = 10;
export const takeValueOfCategories = 10;
export const takeValueOfStories = 10;

export interface Page{
  take : number;
  lastDate : string | undefined;
}

export interface AppEntityState<T extends BaseResponse>{
  entities : EntityState<T>
  page : Page,
  isLastEntities : boolean,
}
