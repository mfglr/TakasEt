import { Page } from "../state/app-entity-state/app-entity-state";

export class UrlHelper{

  static createPaginationQueryString(p : Page) : string{
    if(p.lastValue)
      return `take=${p.take}&lastValue=${p.lastValue}&isDescending=${p.isDescending}`
    return  `take=${p.take}&isDescending=${p.isDescending}`;
  }

}
