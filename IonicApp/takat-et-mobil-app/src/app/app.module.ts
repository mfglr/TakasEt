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
import { userReducer } from './states/user-state/reducer';
import { profileImageReducer } from './states/profile-image-state/reducer';
import { ProfileImageEffect } from './states/profile-image-state/effect';
import { postImageReducer } from './states/post-image-state/reducer';
import { PostImageEffect } from './states/post-image-state/effect';
import { UserEffect } from './states/user-state/effect';

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
    StoreModule.forFeature("UserStore",userReducer),
    StoreModule.forFeature("ProfileImageStore",profileImageReducer),
    StoreModule.forFeature("PostImageStore",postImageReducer),

    EffectsModule.forRoot(),
    EffectsModule.forFeature([LoginEffect]),
    EffectsModule.forFeature([ProfileImageEffect]),
    EffectsModule.forFeature([PostImageEffect]),
    EffectsModule.forFeature([UserEffect]),

    LoginModule,
  ],
  providers: [
    { provide : RouteReuseStrategy, useClass: IonicRouteStrategy },
  ],
  bootstrap: [AppComponent],

})
export class AppModule {}
