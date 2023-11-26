import { Page } from "../models/requests/page";
import { PostFilterRequest } from "../models/requests/post-filter-request";

export class UrlHelper{
  
  static createPaginationQueryString(p : Page) : string{
    return `skip=${p.skip}&take=${p.take}&year=${p.year}&month=${p.month}&day=${p.day}&hour=${p.hour}&minute=${p.minute}&second=${p.second}&milisecond=${p.milisecond}`
  }
  
  static createPostFilteringQueryString(f : PostFilterRequest){
    return `categoryId=${f.categoryId}&userId=${f.userId}&key=${f.key}&includeFolloweds=${f.includeFolloweds}&includeLastSearchings=${f.includeLastSearchings}&${this.createPaginationQueryString(f)}`
  }
}
