export interface AppResponse<T>{
    data? : T;
    errors? : string[];
}