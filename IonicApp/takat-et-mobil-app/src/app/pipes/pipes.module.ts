import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateFormatPipe } from './date-format.pipe';
import { ToShortTextPipe } from './to-short-text.pipe';
import { ToUpperFirstLetterOfAllWordsPipe } from './to-upper-first-letter-of-all-words.pipe';



@NgModule({
  declarations: [
    DateFormatPipe,
    ToShortTextPipe,
    ToUpperFirstLetterOfAllWordsPipe
  ],
  imports: [
    CommonModule
  ],
  exports : [
    DateFormatPipe,
    ToShortTextPipe,
    ToUpperFirstLetterOfAllWordsPipe
  ]
})
export class PipesModule { }
