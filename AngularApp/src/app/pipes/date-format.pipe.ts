import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe implements PipeTransform {
  private static intervals = [
    31557600000,
    2629800000,
    604800000,
    86400000,
    3600000,
    60000,
    1000
  ]
  private static suffixes = ['yil','ay','hafta','gun','saat','dakika','saniye'];

  transform(value: Date | undefined | string): string | undefined{
    if(!value)
      return undefined;
    let time = Date.now() - new Date(value).getTime();
    if(time >= 0 && time < 1000)
      return '0 saniye';
    let rValue : number = 0;
    let i = 0;
    for(;i<DateFormatPipe.intervals.length && (rValue = Math.floor(time / DateFormatPipe.intervals[i])) == 0;i++);
    return `${rValue} ${DateFormatPipe.suffixes[i]}`;
  }
}
