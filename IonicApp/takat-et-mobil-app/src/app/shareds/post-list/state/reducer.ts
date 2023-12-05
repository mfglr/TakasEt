import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { openModalAction, closeModalAction } from "./actions";

export interface State{
    postOfModal : PostResponse | undefined;
    isModalOpen : boolean
}
const initialState : State = {
    postOfModal : undefined,
    isModalOpen : false
}

export const reducer = createReducer(
    initialState,
    on( openModalAction, (state,action) => ({ postOfModal : action.post,isModalOpen : true}) ),
    on( closeModalAction, (state) => ({postOfModal : undefined,isModalOpen : false}))
)