import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateFormatPipe } from './date-format.pipe';
import { ToShortTextPipe } from './to-short-text.pipe';
import { ToUpperFirstLetterOfAllWordsPipe } from './to-upper-first-letter-of-all-words.pipe';
import { MessageDateFormat } from './message-date-format';



@NgModule({
  declarations: [
    DateFormatPipe,
    ToShortTextPipe,
    ToUpperFirstLetterOfAllWordsPipe,
    MessageDateFormat
  ],
  imports: [
    CommonModule
  ],
  exports : [
    DateFormatPipe,
    ToShortTextPipe,
    ToUpperFirstLetterOfAllWordsPipe,
    MessageDateFormat
  ]
})
export class PipesModule { }
