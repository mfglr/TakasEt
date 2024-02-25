export interface AppResponse<T>{
    data : T;
    errors? : string[];
    isError : boolean;
}
