import { createAction, props } from "@ngrx/store";

export const changeActivePageAction = createAction(
    "change active page action",
    props<{activePage : "home_page_state" | "search_page_state"}>()
)
export const nextPageOfPostsAction = createAction("next page of post action")
export const nextPageOfPostsAction