import { Page } from "./page"; 
export interface PostFilterRequest extends Page{
    categoryId? : number;
    userId? : number;
    key? : string;
    includeFolloweds : boolean;
    includeLastSearchings : boolean;
}