import { createSelector, createFeatureSelector } from '@ngrx/store';
import { UserState } from './state';

export const userStore = createFeatureSelector<UserState>('userStoreSlice');
export const getLoginResponse = createSelector(userStore,state => state.loginResponse);
export const isLogin = createSelector(userStore,state => state.isLogin);
