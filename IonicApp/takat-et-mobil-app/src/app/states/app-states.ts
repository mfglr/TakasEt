import { EntityState } from "@ngrx/entity";
import { Page } from "../models/requests/page";
import { PostFilterRequest } from "../models/requests/post-filter-request";

export const takeValueOfPosts = 5;
export const takeValueOfComments = 10;
export const takeValueOfUsers = 1;
export const takeValueOfPostImages = 1;


export function createPage(takeValue : number){
  let date = new Date();
  return {
    skip : 0,
    take : takeValueOfPosts,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds()
  }
}

export function createPostFilterForHomePage() : PostFilterRequest{
  let date  = new Date();
  return {
    skip : 0,
    take : takeValueOfPosts,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds(),
    includeFolloweds : true,
    includeLastSearchings : false,
    categoryId : 0,
    key : "",
    userId : 0
  }
}

export function createPostFilterForSearchingPage() : PostFilterRequest{
  let date  = new Date();
  return {
    skip : 0,
    take : takeValueOfPosts,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds(),
    includeFolloweds : false,
    includeLastSearchings : true,
    categoryId : 0,
    key : "",
    userId : 0
  }
}

export function createPostFilterForSearching(key : string) : PostFilterRequest{
  let date  = new Date();
  return {
    skip : 0,
    take : takeValueOfPosts,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds(),
    includeFolloweds : false,
    includeLastSearchings : false,
    categoryId : 0,
    key : key,
    userId : 0
  }
}

export function createPostFilterForProfilePage(userId : number){
  let date  = new Date();
  return {
    skip : 0,
    take : takeValueOfPosts,
    year : date.getFullYear(),
    month : date.getMonth() + 1,
    day : date.getDate(),
    hour : date.getHours(),
    minute : date.getMinutes(),
    second : date.getSeconds(),
    milisecond : date.getMilliseconds(),
    includeFolloweds : false,
    includeLastSearchings : false,
    categoryId : 0,
    key : "",
    userId : userId
  }
}


export interface AppEntityState<T> extends EntityState<T>{ page : Page; status : boolean;}





