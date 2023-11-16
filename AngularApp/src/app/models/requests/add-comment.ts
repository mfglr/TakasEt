export interface AddComment{
  postId? : number;
  parentId? : number;
  userId : number;
  content : string;
}
