import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LoginModule } from './shareds/login/login.module';
import { postReducer } from './states/post-state/reducer';
import { loginReducer } from './states/login_state/reducer';
import { LoginEffect } from './states/login_state/effect';
import { userEntityReducer } from './states/user-entity-state/reducer';
import { userImageEntityReducer } from './states/user-image-entity-state/reducer';
import { UserImageEntityEffect } from './states/user-image-entity-state/effect';
import { postImageReducer } from './states/post-image-state/reducer';
import { PostImageEffect } from './states/post-image-state/effect';
import { UserEntityEffect } from './states/user-entity-state/effect';
import { profileReducer } from './states/profile-state/reducer';
import { ProfileEffect } from './states/profile-state/effect';
import { AppEffect } from './states/effect';
import { SwiperHeaderModule } from './shareds/swiper-header/swiper-header.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,

    StoreModule.forRoot(),
    StoreModule.forFeature("LoginState",loginReducer),
    StoreModule.forFeature("PostStore",postReducer),
    StoreModule.forFeature("UserEntityStore",userEntityReducer),
    StoreModule.forFeature("UserImageEntityStore",userImageEntityReducer),
    StoreModule.forFeature("PostImageStore",postImageReducer),
    StoreModule.forFeature("ProfileStore",profileReducer),

    EffectsModule.forRoot(),
    EffectsModule.forFeature([AppEffect]),
    EffectsModule.forFeature([LoginEffect]),
    EffectsModule.forFeature([UserImageEntityEffect]),
    EffectsModule.forFeature([PostImageEffect]),
    EffectsModule.forFeature([UserEntityEffect]),
    EffectsModule.forFeature([ProfileEffect]),

    SwiperHeaderModule,

    LoginModule,
  ],
  providers: [
    { provide : RouteReuseStrategy, useClass: IonicRouteStrategy },
  ],
  bootstrap: [AppComponent],

})
export class AppModule {}
