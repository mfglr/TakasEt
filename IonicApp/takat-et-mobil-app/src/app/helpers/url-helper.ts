import { Page } from "../state/app-entity-state/app-entity-state";

export class UrlHelper{

  static createPaginationQueryString(p : Page) : string{
    if(p.lastId)
      return `take=${p.take}&lastId=${p.lastId}`
    return  `take=${p.take}`;
  }

}
