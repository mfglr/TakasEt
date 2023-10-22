import { Page } from "../states/app-states";

export class UrlHelper{
  static createPaginationUrl(url : string,page : Page) : string{
    return `${url}?skip=${page.skip}&take=${page.take}&firstQueryDate=${page.firstQueryDate}`
  }
}
