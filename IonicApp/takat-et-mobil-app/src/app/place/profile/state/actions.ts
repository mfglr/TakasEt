import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const changeActiveTabAction = createAction( "[Profile Store] changeActiveTab", props<{activeTab : number}>() )
export const nextPostsAction = createAction("[Profile Store] nextPageAction")
export const nextPostsSuccessAction = createAction("[Profile Store] nextPageSuccessAction",props<{payload : PostResponse[]}>())
