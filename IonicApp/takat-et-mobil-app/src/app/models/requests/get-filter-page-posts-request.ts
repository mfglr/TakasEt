import { Page } from "src/app/states/app-entity-state/app-entity-state";
import { BaseRequest } from "./base-request";

export interface GetFilterPagePostsRequest extends Page,BaseRequest{
  categoryIds : string | undefined,
  key : string | undefined
}
