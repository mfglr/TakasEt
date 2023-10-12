import { Observable } from "rxjs";
import { NoContentResponse } from "../models/responses/no-content-response";

export interface Followable{
  follow(id : string) : Observable<NoContentResponse>
  unfollow(id : string) : Observable<NoContentResponse>
  isFollowed(id : string) : Observable<boolean>
}
