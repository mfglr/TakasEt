import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState, HOME_PAGE_STATE, HomePageState, SEARCH_PAGE_STATE, SearcPageState, PageStateThatHasPostsState } from "./app-states";

export const selectAppState = createFeatureSelector<AppState>("appStoreSlice");
export const selectHomePageState = createSelector( selectAppState, (state : AppState) : HomePageState => state.homePageState )
export const selectSearcPageState = createSelector( selectAppState, (state : AppState) : SearcPageState => state.searchPageState )

const selectActivePageStateThatHasPostsState = createSelector(
    selectAppState,
    (state) : PageStateThatHasPostsState | undefined => {
        if(state.activePage == HOME_PAGE_STATE)
            return state.homePageState;
        else if(state.activePage == SEARCH_PAGE_STATE)
            return state.searchPageState;
        else
            return undefined;
    }
)
export const selectPostsState = createSelector(selectActivePageStateThatHasPostsState,state => state?.posts)