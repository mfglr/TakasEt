import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'messageDateFormat'
})
export class MessageDateFormat implements PipeTransform {


  transform(value: Date | undefined | string): string | undefined{
    if(value)
      return new Date(value).toTimeString();
    return undefined;
  }
}
