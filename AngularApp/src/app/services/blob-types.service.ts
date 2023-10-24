import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BlobTypesService {
  private types : {extention : string, blobType : string }[] =
  [
    { extention : 'jpg', blobType : 'image/jpg'},
    { extention : 'jpeg', blobType : 'image/jpeg'},
    { extention : 'png', blobType : 'image/png'},
  ]

  getBlobType(index : number) : string{
    return this.types[index].blobType
  }
  getBlobTypeByExtention(extention : string) : string | undefined{
    return this.types.find(x => x.extention.toLowerCase() === extention.toLowerCase())?.blobType
  }
}
