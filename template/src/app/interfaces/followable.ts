import { Observable } from "rxjs";
import { NoContentResponse } from "../models/responses/no-content-response";

export interface Followable{
  follow(ownerId : string) : Observable<NoContentResponse>
  unfollow(ownerId : string) : Observable<NoContentResponse>
}
