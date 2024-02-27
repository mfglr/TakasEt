export interface BaseAppresponse{
  errors? : string[];
  isError : boolean;
}

export interface AppResponse<T> extends BaseAppresponse{
  data? : T;
}
