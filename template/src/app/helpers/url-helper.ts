import { Page } from "../states/state";

export class UrlHelper{
  static createPaginationUrl(url : string,page : Page) : string{
    return `${url}?skip=${page.skip}&take=${page.take}&firstQueryDate=${page.firstQueryDate}`
  }
}
