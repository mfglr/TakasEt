import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppFileReaderService {


  private byteArrayToNumber(array :Uint8Array,offset: number,digit : number) {
    var value = 0;
    for(var i = digit - 1 ,j = 0; i >= 0; i--,j++){
      value += (Math.pow(256,j) * array[i + offset])
    }
    return value;
  };

  public getFiles(array : Uint8Array):{ file : Uint8Array, extention : string }[]{
    let offset = 0;
    let ret : { file : Uint8Array, extention : string }[] = [];
    while(offset < array.length){
      let lengthOfTFileLength = this.byteArrayToNumber(array,offset,1)
      let fileLength = this.byteArrayToNumber(array,offset += 1,lengthOfTFileLength);
      let extentionLength = this.byteArrayToNumber(array,offset += lengthOfTFileLength,1);
      let extention = new TextDecoder("utf-8").decode(
        array.subarray(offset += 1,offset += extentionLength).reverse()
      );
      let file = array.subarray(offset,offset += fileLength)
      ret.push( { file : file, extention : extention } );
    }
    return ret;
  }
}
