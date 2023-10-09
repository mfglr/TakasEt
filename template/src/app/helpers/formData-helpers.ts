export class FormDataHelper{

  private static getExtention(file : File): string {
    var list = file.name.split('.');
    return list[list.length - 1];
  }

  private static getExtenstions(files : File[]) : string {
    let value = '';
    for(let i = 0; i < files.length - 1; i++)
      value += `${this.getExtention(files[i])},`
    value += this.getExtention(files[files.length - 1]);
    return value;
  }

  static createFormDataForAddPost(value : {userId : string,categoryId : string,title : string,content : string,files : File[]}) : FormData{
    let formData = new FormData();
    for(let i = 0; i < value.files.length; i++)
      formData.append("streams",value.files[i]);
    formData.append("countOfImages",value.files.length.toString());
    formData.append("extentions",this.getExtenstions(value.files));
    formData.append("content",value.content);
    formData.append("title",value.title);
    formData.append("categoryId",value.categoryId);
    formData.append("userId",value.userId);
    return formData;
  }

  static createFormDataForAddProfileImage(value : {file : File}) : FormData{
    let formData = new FormData();
    formData.append('extention',this.getExtention(value.file));
    formData.append('stream',value.file);
    return formData;
  }

}
