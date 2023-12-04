// import { Injectable } from "@angular/core";
// import { Actions, createEffect, ofType } from "@ngrx/effects";
// import { CommentService } from "src/app/services/comment.service";
// import { nextPageOfChildren, nextPageOfChildrenSuccess, nextPageOfComments, nextPageOfCommentsSuccess, resetCommentToReplyAction, shareComment, shareCommentSuccess } from "./action";
// import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
// import { Store } from "@ngrx/store";
// import { CommentModalStateCollection } from "./state";
// import { selectCommentToReplyState, selectStatusAndPage, selectStatusAndPageOfChildren } from "./selector";
// import { AddComment } from "src/app/models/requests/add-comment";
// import { LoginState } from "src/app/shareds/login/login_state/reducer";


// @Injectable()
// export class CommentModalCollectionEffect{
//     constructor(
//         private actions : Actions,
//         private commentService : CommentService,
//         private commentModalState : Store<CommentModalStateCollection>,
//         private loginStore : Store<LoginState>
//     ) {}

//     shareComment$ = createEffect(() => {
//         return this.actions.pipe(
//             ofType(shareComment),
//             mergeMap(action => this.loginStore.select(selectUserId).pipe(
//                 first(),
//                 mergeMap(userId => this.commentModalState.select(selectCommentToReplyState({postId : action.postId})).pipe(
//                     first(),
//                     mergeMap((state) => {
//                         let request : AddComment = {content : action.content,userId : userId!} 
//                         if(state.ownerType == "post") request.postId = state.ownerId;
//                         else request.parentId = state.ownerId;
//                         return this.commentService.addComment(request).pipe(
//                             withLatestFrom(
//                                 this.loginStore.select(selectProfileImage),
//                                 this.loginStore.select(selectUserName)
//                             ),
//                             mergeMap(
//                                 ([response,profileImage,userName]) => {
//                                     response.userName = userName!
//                                     response.profileImage = profileImage!
//                                     return of(
//                                         shareCommentSuccess({postId : action.postId,response : response}),
//                                         resetCommentToReplyAction({postId : action.postId})
//                                     )
//                                 }
//                             )
//                         )
//                     })
//                 ))
//             )),
//         )
//     })

//     nextPageOfComments$ = createEffect(() =>{
//         return this.actions.pipe(
//             ofType(nextPageOfComments),
//             mergeMap(action => this.commentModalState.select(selectStatusAndPage({postId : action.postId})).pipe(
//                 first(),
//                 filter(x => !x.status),
//                 mergeMap(x => this.commentService.getCommnetsByPostId(action.postId,x.page)),
//                 mergeMap(response => of(nextPageOfCommentsSuccess({postId : action.postId, payload : response})))
//             ))
//         )
//     })

//     nextPageOfChildren = createEffect(() =>{
//         return this.actions.pipe(
//             ofType(nextPageOfChildren),
//             mergeMap(   
//                 action => this.commentModalState.select(
//                     selectStatusAndPageOfChildren({postId : action.postId,commentId : action.commentId})
//                 ).pipe(
//                     first(),
//                     filter(x => !x.status),
//                     mergeMap(x => this.commentService.getChildren(action.commentId,x.page)),
//                     mergeMap(response => of(nextPageOfChildrenSuccess({
//                         postId : action.postId,commentId : action.commentId,payload : response
//                     })))
//                 )
//             )
//         )
//     })
// }