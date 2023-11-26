import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostImageSliderComponent } from './post-image-slider/post-image-slider.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { LikeButtonComponent } from './like-button/like-button.component';
@NgModule({
  declarations: [
    PostImageSliderComponent,
    LoginComponent,
    LikeButtonComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports : [
    PostImageSliderComponent,
    LoginComponent,
    LikeButtonComponent
  ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedsModule { }
