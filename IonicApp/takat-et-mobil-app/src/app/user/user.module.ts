import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { userModuleCollectionReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserModuleCollectionEffect } from './state/effect';
import { UserRoutingModule } from './user-routing-module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UserRoutingModule,
    StoreModule.forFeature("UserModuleCollectionStore",userModuleCollectionReducer),
    EffectsModule.forFeature([UserModuleCollectionEffect])
  ]
})
export class UserModule { }
