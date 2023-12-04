import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { closeModalAction, openModalAction } from "./actions";

export interface State{
    postOfModal : PostResponse | undefined;
    isOpenModal : boolean
}
const initialState : State = {
    postOfModal : undefined,
    isOpenModal : false
}

export const reducer = createReducer(
    initialState,
    on( openModalAction, (state,action) => ({ postOfModal : action.post,isOpenModal : true}) ),
    on( closeModalAction, (state) => ({isOpenModal : false,postOfModal : undefined}))
)