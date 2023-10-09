import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoadFilesComponent } from './shareds/load-files/load-files.component';
import { DisplayPostComponent } from './components/display-post/display-post.component';
import { CategoryInputComponent } from './shareds/category-input/category-input.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { StoreModule } from '@ngrx/store';
import { userReducer } from './states/user/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserEffect } from './states/user/effect';
import { DisplayPostImagesComponent } from './components/display-post/display-post-images/display-post-images.component';
import { DisplayProfileImageComponent } from './shareds/display-profile-image/display-profile-image.component';
import { AppHubConnectionService } from './services/app-hub-connection.service';
import { DisplayPostContentComponent } from './components/display-post/display-post-content/display-post-content.component';
import { LikeButtonComponent } from './shareds/like-button/like-button.component';
import { SwapRequestComponent } from './modals/swap-request/swap-request.component';
import { SwapRequestItemComponent } from './modals/swap-request/swap-request-item/swap-request-item.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoadFilesComponent,
    DisplayPostComponent,
    CategoryInputComponent,
    CreatePostComponent,
    DisplayPostImagesComponent,
    DisplayProfileImageComponent,
    DisplayPostContentComponent,
    LikeButtonComponent,
    SwapRequestComponent,
    SwapRequestItemComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(),
    StoreModule.forFeature("userStoreSlice" , userReducer),
    EffectsModule.forRoot([UserEffect])
  ],
  providers: [AppHubConnectionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
