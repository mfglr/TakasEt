import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LoginModule } from './shareds/login/login.module';
import { AppEffect } from './state/effect';
import { SwiperHeaderModule } from './shareds/swiper-header/swiper-header.module';
import { appReducer } from './state/reducer';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,

    StoreModule.forRoot(),
    StoreModule.forFeature("AppStore",appReducer),

    EffectsModule.forRoot(),
    EffectsModule.forFeature([AppEffect]),
    SwiperHeaderModule,

    LoginModule,
  ],
  providers: [
    { provide : RouteReuseStrategy, useClass: IonicRouteStrategy },
  ],
  bootstrap: [AppComponent],

})
export class AppModule {}
