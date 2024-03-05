import { EntityState } from "@ngrx/entity";
import { BaseResponse } from "src/app/models/responses/base-response";

export const takeValueOfPosts = 15;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 10;
export const takeValueOfPostImages = 10;
export const takeValueOfCategories = 10;
export const takeValueOfStories = 10;
export const takeValueOfConversation = 10;
export const takevalueOfMessage = 20;


export interface Pagination<T extends BaseResponse>{
  entity : T;
  paginationProperty : string;
}

export interface Page{
  take : number;
  lastValue : number | string | undefined;
  isDescending : boolean;
}

export interface AppEntityState<E extends BaseResponse,T extends Pagination<E>>{
  entities : EntityState<T>
  page : Page,
  isLast : boolean,
}
