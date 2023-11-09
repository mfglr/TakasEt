import { Page } from "../states/app-states";

export class UrlHelper{
  static createPaginationUrl(url : string,page : Page) : string{
    return `${url}?skip=${page.skip}&take=${page.take}&year=${page.year}&month=${page.month}&day=${page.day}&hour=${page.hour}&minute=${page.minute}&second=${page.second}&milisecond=${page.milisecond}`
  }
}
