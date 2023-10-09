import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppFileReaderService {

  private sizeOfInt : number = 4;
  private isBigEndian : number = 1;
  private byteArrayToNumber(source :Uint8Array,digit : number) {
    var value = 0;
    for(var i = digit - 1 ,j = 0; i >= 0; i--,j++)
      value += (Math.pow(256,j) * source[i])
    return value;
  };

  private setSystemInformations(source : Uint8Array){
    this.sizeOfInt = this.byteArrayToNumber(source.subarray(0,1),1);
    this.isBigEndian = this.byteArrayToNumber(source.subarray(1,2),1);
  }

  private readInt(source : Uint8Array,offset : number) : number{
    var data = source.subarray(offset,offset + this.sizeOfInt);
    if(!this.isBigEndian) data.reverse();
    return this.byteArrayToNumber(data,this.sizeOfInt);
  }

  public getFiles(source : Uint8Array):{ file : Uint8Array, extention : string }[]{
    this.setSystemInformations(source);
    let offset = 2;
    let ret : { file : Uint8Array, extention : string }[] = [];
    while(offset < source.length){
      let lengthOfExtention = this.readInt(source,offset)
      offset += this.sizeOfInt;
      let extention = new TextDecoder("utf-8").decode(
        source.subarray(offset, offset += lengthOfExtention).reverse()
      );
      let lengthOfFile = this.readInt(source,offset)
      offset += this.sizeOfInt;
      let file = source.subarray(offset,offset += lengthOfFile)
      ret.push( { file : file, extention : extention } );
    }
    return ret;
  }
}
