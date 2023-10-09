import { Observable } from "rxjs";
import { NoContentResponse } from "../models/responses/no-content-response";

export interface Likeable{
  like(ownerId : string) : Observable<NoContentResponse>;
  unlike(ownerId : string) : Observable<NoContentResponse>;
}
