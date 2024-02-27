import { Page } from "../state/app-entity-state/app-entity-state";

export class UrlHelper{

  static createPaginationQueryString(p : Page) : string{
    if(p.lastDate)
      return `take=${p.take}&lastDate=${p.lastDate}`
    return  `take=${p.take}`;
  }

}
