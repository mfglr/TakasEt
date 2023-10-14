import { Observable } from "rxjs";
import { NoContentResponse } from "../models/responses/no-content-response";

export interface Likeable{
  like(id : string) : Observable<NoContentResponse>;
  unlike(id : string) : Observable<NoContentResponse>;
  isLiked(id : string) : Observable<boolean>;
}
