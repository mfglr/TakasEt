import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { userModuleCollectionReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserModuleCollectionEffect } from './state/effect';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature("UserModuleCollectionStore",userModuleCollectionReducer),
    EffectsModule.forFeature([UserModuleCollectionEffect])
  ]
})
export class UserModule { }
