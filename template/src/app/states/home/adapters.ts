import { createEntityAdapter } from "@ngrx/entity"
import { CommentState, PostState, UserState } from "./states"

export const adapterOfChildren = createEntityAdapter<CommentState>({
  selectId : (state) => state.comment.id
})
export const adapterOfComments = createEntityAdapter<CommentState>({
  selectId : (state) => state.comment.id
})
export const adapterOfUsersLiked = createEntityAdapter<UserState>({
  selectId : (state) => state.user.id
})
export const adapterOfUsersVeiwed = createEntityAdapter<UserState>({
  selectId : (state) => state.user.id
})
export const adapterOfHome = createEntityAdapter<PostState>({
  selectId : (state) => state.post.id
})
