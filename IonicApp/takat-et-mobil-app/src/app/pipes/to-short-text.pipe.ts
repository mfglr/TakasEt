import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toShortText'
})
export class ToShortTextPipe implements PipeTransform {

  transform(value: string | undefined,length : number = 30): string {
    return value ? value.length < length ? value : value.substring(0,length) : ''; 
  }

}
