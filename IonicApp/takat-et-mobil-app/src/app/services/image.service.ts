import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { Observable } from "rxjs";
import { BaseAppresponse } from "../models/responses/app-response";
import { ContainerName } from "../models/enums/containerNames";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn : "root"
})
export class ImageService{

  private readonly baseUrl : string = environment.photoStockService;

  constructor(private readonly httpClient : NativeHttpClientService) {}

  private dataURItoFile(dataURI : string,format : string) {
    const byteString = atob(dataURI);
    const int8Array = new Uint8Array(new ArrayBuffer(byteString.length));
    for (let i = 0; i < byteString.length; i++)
      int8Array[i] = byteString.charCodeAt(i);
    const type = `image/${format}`
    return new File([new Blob([int8Array], { type: type })],`${crypto.randomUUID()}.${format}`,{ type : type });
 }

  uploadUserImage(dataUri : string,format : string) : Observable<BaseAppresponse>{
    var formData = new FormData();
    formData.append("containerName",ContainerName.userImages);
    formData.append("stream",this.dataURItoFile(dataUri,format));
    return this.httpClient.postFormData(`${this.baseUrl}/image/uploadimage`,formData)
  }

  downloadImage(containerName : string, blobName: string) : Observable<string>{
    return this.httpClient.getBlob(`${this.baseUrl}/${containerName}/${blobName}`)
  }

}
