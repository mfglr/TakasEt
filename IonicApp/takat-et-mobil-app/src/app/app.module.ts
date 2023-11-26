import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';
import { appLoginReducer } from './states/login_state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { pagePostReducer } from './states/post-state/reducer';
import { commentModalCollectionReducer } from './states/comment_modal_state/reducer';
import { AppLoginEffect } from './states/login_state/effect';
import { CommentModalCollectionEffect } from './states/comment_modal_state/effect';
import { PagePostEffect } from './states/post-state/effect';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedsModule } from './shareds/shareds.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    SharedsModule,
    ReactiveFormsModule,
    FormsModule,
    StoreModule.forRoot(),
    StoreModule.forFeature("AppLoginState", appLoginReducer),
    StoreModule.forFeature("CommentModalStateCollection", commentModalCollectionReducer),
    StoreModule.forFeature("PagePostStore",pagePostReducer),
    EffectsModule.forRoot(),
    EffectsModule.forFeature([AppLoginEffect]),
    EffectsModule.forFeature([CommentModalCollectionEffect]),
    EffectsModule.forFeature([PagePostEffect])
  ],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule {}
