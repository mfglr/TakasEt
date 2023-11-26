import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppLoginState } from "./state";

const selectAppLoginState = createFeatureSelector<AppLoginState>("AppLoginState");
export const selectAccessToken = createSelector(selectAppLoginState,state => state.loginResponse?.accessToken);
export const selectProfileImage = createSelector(selectAppLoginState,state => state.profileImage);
export const selectUserId = createSelector(selectAppLoginState,state => state.loginResponse?.id);
export const selectUserName = createSelector(selectAppLoginState,state => state.loginResponse?.userName);
export const isLogin = createSelector(selectAppLoginState,state => state.isLogin);