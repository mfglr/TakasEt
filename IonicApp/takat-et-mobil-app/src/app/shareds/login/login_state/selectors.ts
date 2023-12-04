import { createFeatureSelector, createSelector } from "@ngrx/store";
import { LoginState } from "./reducer";

const selectAppLoginState = createFeatureSelector<LoginState>("LoginState");
export const selectAccessToken = createSelector(selectAppLoginState,state => state.loginResponse?.accessToken);
export const selectUserId = createSelector(selectAppLoginState,state => state.loginResponse?.userId);
export const isLogin = createSelector(selectAppLoginState,state => state.isLogin);