import { Injectable } from "@angular/core";
import { Actions } from "@ngrx/effects";
import { UserImageService } from "../services/user-image.service";
import { PostImageService } from "../services/post-image.service";
import { LoginService } from "../services/login.service";
import { PostService } from "../services/post.service";
import { UserService } from "../services/user.service";

@Injectable()
export class AppEffect{

  constructor(
    private actions : Actions,
    private userImageService : UserImageService,
    private postImageService : PostImageService,
    private loginService : LoginService,
    private postService : PostService,
    private userService : UserService
  ) {}




}
