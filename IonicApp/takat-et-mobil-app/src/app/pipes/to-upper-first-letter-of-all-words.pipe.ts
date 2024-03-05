import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toUpperFirstLetterOfAllWords'
})
export class ToUpperFirstLetterOfAllWordsPipe implements PipeTransform {

  transform(value: string | undefined): string {
    if(value && value.length > 0){
      let r : string = '';
      r += value[0].toLocaleUpperCase();
      for(let i = 1; i < value.length; i++){
        if(value[i] == ' '){
          r += value[i];
          i++;
          while(i < value.length && value[i] == ' '){
            r += value[i];
            i++;
          }
          if(i >= value.length)
            break;
          r += value[i].toLocaleUpperCase()
        }
        else
          r += value[i].toLocaleLowerCase();
      }
      return r;
    }
    return "";
  }

}
