import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { Observable, from, map, mergeMap } from "rxjs";
import { ContainerName } from "../models/enums/containerNames";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn : "root"
})
export class FileService{

  private readonly fileReaderServiceUrl : string = environment.fileStockReaderService;
  private readonly fileWriterServiceUrl : string = environment.fileStockWriterService;

  constructor(private readonly httpClient : NativeHttpClientService) {}

  private base64ToUrl(base64String : string, contentType = '') {
    const byteCharacters = atob(base64String);
    var array = new Uint8Array(byteCharacters.length)
    for (let i = 0; i < byteCharacters.length; i++)
      array[i] = byteCharacters.charCodeAt(i);
    return URL.createObjectURL(new Blob([array], { type: contentType }));
  }

  private webPathtoFile(webPath : string,format : string) {
    return fetch(webPath)
      .then(response => response.blob())
      .then(blob => new File([blob],`${crypto.randomUUID()}.${format}`,{ type :`image/${format}`}))
  }

  private async WebPathsToFormData(paths : {webPath : string,format : string}[],containerName : string){
    var formData = new FormData();
    for(let i = 0; i < paths.length;i++){
      var file = await this.webPathtoFile(paths[i].webPath,paths[i].format);
      formData.append("stream",file);
    }
    formData.append("containerName",containerName);
    return formData;
  }

  uploadImageFile(webPath : string,format : string,containerName : ContainerName){
    return from(this.WebPathsToFormData([{webPath : webPath,format : format}],containerName))
      .pipe(
        mergeMap(formData => this.httpClient.postFormData<{
          containerName : string,
          blobName : string,
          extention : string,
          height : number,
          width : number
        }>(`${this.fileWriterServiceUrl}/file/UploadImageFile`,formData))
      )
  }

  uploadImageFiles(paths : {webPath : string,format : string}[],containerName : ContainerName){
    return from(this.WebPathsToFormData(paths,containerName)).pipe(
      mergeMap(
        formData => this.httpClient.postFormData<{
          containerName : string,
          blobName : string,
          extention : string,
          height : number,
          width : number
        }[]>(`${this.fileWriterServiceUrl}/file/UploadImageFiles`,formData)
      )
    )
  }

  downloadFile(containerName : string, blobName: string,extention : string) : Observable<string>{
    return this.httpClient.getBlob(
      `${this.fileReaderServiceUrl}/file/DownloadFile/${containerName}/${blobName}`,
      extention
    ).pipe(map(base64 => this.base64ToUrl(base64,extention)))

  }

}
