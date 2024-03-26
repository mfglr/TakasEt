export interface CreateMessage{
  id : string;
  receiverId : string;
  content? : string;
  sendDate : number;
  images? : {
    containerName : string;
    blobName : string;
    extention : string
    height : number;
    width : number;
  }[]
}
