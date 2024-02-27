import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { Observable } from "rxjs";
import { BaseAppresponse } from "../models/responses/app-response";
import { ContainerName } from "../models/enums/containerNames";

@Injectable({
  providedIn : "root"
})
export class ImageService{

  private readonly baseUrl : string = "https://localhost:7187/image";

  constructor(private readonly httpClient : NativeHttpClientService) {}

  uploadUserImage(file : File) : Observable<BaseAppresponse>{
    var formData = new FormData();
    formData.append("containerName",ContainerName.userImages);
    formData.append("stream",file);
    return this.httpClient.postFormData(`${this.baseUrl}/uploadimage`,formData)
  }

  downloadImage(containerName : string, blobName: string) : Observable<string>{
    return this.httpClient.getBlob(`${this.baseUrl}/${containerName}/${blobName}`)
  }

}
