import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";
import { createPostState, createPostStates, createUserState, createUserStates, postAdapter, userAdapter } from "./app_state/app-adapters";
import { UsersState, takeValueOfComments, takeValueOfPosts, takeValueOfUsers } from "./app_state/app-states";

export class UsersStateFunctions{
  static addFollower(state : UsersState,follower : UserResponse,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { followers : userAdapter.addOne(createUserState(follower),state.entities[userId]!.followers)}
    },state)
  }
  static removeFollower(state : UsersState,followerId : string,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { followers : userAdapter.removeOne(followerId,state.entities[userId]!.followers)}
    },state)
  }
  static loadFollowers(state : UsersState,followers : UserResponse[],userId : string){
    let page = state.entities[userId]!.followers.page;
    return userAdapter.updateOne({
      id : userId,
      changes : {
        followers : {
          ...userAdapter.addMany(createUserStates(followers),state.entities[userId]!.followers),
          status : followers.length < takeValueOfUsers,
          page : {...page,skip : page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addFollowed(state : UsersState,followed : UserResponse,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { followeds : userAdapter.addOne(createUserState(followed),state.entities[userId]!.followeds)}
    },state)
  }
  static removeFollowed(state : UsersState,followedId : string,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { followeds : userAdapter.removeOne(followedId,state.entities[userId]!.followeds)}
    },state)
  }
  static loadFolloweds(state : UsersState,followeds : UserResponse[],userId : string){
    let page = state.entities[userId]!.followeds.page;
    return userAdapter.updateOne({
      id : userId,
      changes : {
        followeds : {
          ...userAdapter.addMany(createUserStates(followeds),state.entities[userId]!.followeds),
          status : followeds.length < takeValueOfUsers,
          page : {...page,skip : page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addPost(state : UsersState,post : PostResponse,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { posts : postAdapter.addOne(createPostState(post),state.entities[userId]!.posts)}
    },state)
  }
  static removePost(state : UsersState,postId : string,userId : string){
    return userAdapter.updateOne({
      id : userId,
      changes : { posts : postAdapter.removeOne(postId,state.entities[userId]!.posts)}
    },state)
  }
  static loadPosts(state : UsersState,posts : PostResponse[],userId : string){
    let page = state.entities[userId]!.followers.page;
    return userAdapter.updateOne({
      id : userId,
      changes : {
        posts : {
          ...postAdapter.addMany(createPostStates(posts),state.entities[userId]!.posts),
          status : posts.length < takeValueOfPosts,
          page : {...page,skip : page.skip + takeValueOfPosts}
        }
      }
    },state)
  }
}
