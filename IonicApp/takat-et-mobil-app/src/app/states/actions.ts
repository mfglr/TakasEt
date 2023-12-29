import { createAction, props } from "@ngrx/store"
import { PostResponse } from "../models/responses/post-response";
import { UserImageResponse } from "../models/responses/profile-image-response";
import { UserResponse } from "../models/responses/user-response";
import { PostImageResponse } from "../models/responses/post-image-response";

export const loadPostsAction = createAction(
  "[App Store] load posts",
  props<{posts : PostResponse[]}>()
);
export const loadUsersAction = createAction(
  "[App Store] load users",
  props<{users : UserResponse[]}>()
)

