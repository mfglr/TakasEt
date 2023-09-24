import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ArticleAbstractComponent } from './components/article/article-abstract/article-abstract.component';
import { DisplayImagesComponent } from './shareds/display-images/display-images.component';
import { LoadFilesComponent } from './shareds/load-files/load-files.component';
import { UploadFilesComponent } from './shareds/upload-files/upload-files.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ArticleAbstractComponent,
    LoadFilesComponent,
    DisplayImagesComponent,
    UploadFilesComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
