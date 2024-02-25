import { createFeatureSelector, createSelector } from "@ngrx/store"
import { LoginState } from "./reducer"

const selectStore = createFeatureSelector<LoginState>("LoginStore")
export const selectIsLogin = createSelector(selectStore,state => state.isLogin)
export const selectLoginResponse = createSelector(selectStore,state => state.loginResponse)
export const selectUserId = createSelector(selectLoginResponse,state => state?.userId)
export const selectAccessToken = createSelector(selectLoginResponse,state => state?.accessToken)
