import { Page } from "src/app/state/app-entity-state/app-entity-state";

export interface GetMessages extends Page{
  receiverId : string;
}
