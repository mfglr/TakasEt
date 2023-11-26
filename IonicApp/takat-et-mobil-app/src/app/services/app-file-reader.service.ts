import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppFileReaderService {
  
  private byteArrayToNumber(source :Uint8Array,digit : number) {
    var value = 0;
    for(var i = digit - 1 ,j = 0; i >= 0; i--,j++)
      value += (Math.pow(256,j) * source[i])
    return value;
  };

  private readInt(source : Uint8Array,offset : number,sizeOfInt : number, isBigEndian : number) : number{
    var data = source.subarray(offset,offset + sizeOfInt);
    if(!isBigEndian) data.reverse();
    return this.byteArrayToNumber(data,sizeOfInt);
  }

  public getFiles(source : Uint8Array):{ file : Uint8Array, extention : string }[]{
    let sizeOfInt = this.byteArrayToNumber(source.subarray(0,1),1);
    let isBigEndian = this.byteArrayToNumber(source.subarray(1,2),1);
    let offset = 2;
    let ret : { file : Uint8Array, extention : string }[] = [];
    while(offset < source.length){
      
      let lengthOfExtention = this.readInt(source,offset,sizeOfInt,isBigEndian)
      offset += sizeOfInt;
      let extention = new TextDecoder("utf-8").decode( source.subarray(offset, offset += lengthOfExtention).reverse() );
      
      let lengthOfFile = this.readInt(source,offset,sizeOfInt,isBigEndian)
      offset += sizeOfInt;
      let file = source.subarray(offset,offset += lengthOfFile)
      
      ret.push( { file : file, extention : extention } );
    }
    return ret;
  }

}
