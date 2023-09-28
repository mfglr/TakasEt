import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoadFilesComponent } from './shareds/load-files/load-files.component';
import { UploadFilesComponent } from './shareds/upload-files/upload-files.component';
import { PostComponent } from './components/post/post.component';
import { CategoryInputComponent } from './shareds/category-input/category-input.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { StoreModule } from '@ngrx/store';
import { userReducer } from './states/user/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserEffect } from './states/user/effect';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoadFilesComponent,
    UploadFilesComponent,
    PostComponent,
    CategoryInputComponent,
    CreatePostComponent
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
