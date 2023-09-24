import { ContainerName } from "../models/containerName";

export class FileHelper{

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

  public static createFormData(files : File[],containerName : ContainerName,ownerId : string) : FormData {
    let formData = new FormData();
    for(let i = 0; i < files.length; i++)
      formData.append("streams",files[i]);
    formData.append("extentions",this.getExtenstions(files));
    formData.append("containerName",containerName);
    formData.append("ownerId",ownerId);
    return formData;
  }

}
