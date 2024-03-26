import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { AccountModule } from './account/account.module';
import { ChatModule } from './chat/chat.module';
import { testReducer } from './state/test/reducer';
import { TestEffect } from './state/test/effect';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,
    StoreModule.forRoot(),
    EffectsModule.forRoot(),
    StoreModule.forFeature("TestStore",testReducer),
    EffectsModule.forFeature([TestEffect]),
    ChatModule,
    AccountModule,
  ],
  providers: [
    { provide : RouteReuseStrategy, useClass: IonicRouteStrategy },
  ],
  bootstrap: [AppComponent],

})
export class AppModule {}
