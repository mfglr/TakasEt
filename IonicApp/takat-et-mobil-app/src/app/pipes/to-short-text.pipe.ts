import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toShortText'
})
export class ToShortTextPipe implements PipeTransform {

  transform(value: string | undefined,length : number = 30): string {
    if(value == undefined)
      return "";
    if(value.length <= length)
      return value;
    return (value ? value.length < length ? value : value.substring(0,length) : '') + '...';
  }

}
