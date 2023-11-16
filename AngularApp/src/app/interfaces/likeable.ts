import { Observable } from "rxjs";
import { NoContentResponse } from "../models/responses/no-content-response";

export interface Likeable{
  like(id : number) : Observable<NoContentResponse>;
  unlike(id : number) : Observable<NoContentResponse>;
  isLiked(id : number) : Observable<boolean>;
}
