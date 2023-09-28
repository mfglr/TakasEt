import { ContainerName } from "../models/enums/containerName";

export class FormDataHelper{

  public static getExtention(file : File): string {
    var list = file.name.split('.');
    return list[list.length - 1];
  }

  public static getExtenstions(files : File[]) : string {
    let value = '';
    for(let i = 0; i < files.length - 1; i++)
      value += `${this.getExtention(files[i])},`
    value += this.getExtention(files[files.length - 1]);
    return value;
  }

  public static createFormDataForUploadFiles(files : File[],containerName : ContainerName,ownerId : string) : FormData {
    let formData = new FormData();
    for(let i = 0; i < files.length; i++)
      formData.append("streams",files[i]);
    formData.append("extentions",this.getExtenstions(files));
    formData.append("containerName",containerName);
    formData.append("ownerId",ownerId);
    return formData;
  }

  public static createFormDataForAddPost(value : {userId : string,categoryId : string,title : string,content : string,files : File[]}) : FormData{
    let formData = new FormData();
    for(let i = 0; i < value.files.length; i++)
      formData.append("streams",value.files[i]);
    formData.append("extentions",this.getExtenstions(value.files));
    formData.append("containerName",ContainerName.postImage);
    formData.append("content",value.content);
    formData.append("title",value.title);
    formData.append("categoryId",value.categoryId);
    formData.append("userId",value.userId);
    return formData;
  }

}
