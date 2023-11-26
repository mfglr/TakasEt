import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { HomePostComponent } from './home-post/home-post.component';
import { HomePostListComponent } from './home-post-list/home-post-list.component';
import { SharedsModule } from 'src/app/shareds/shareds.module';
import { DateFormatPipe } from 'src/app/pipes/date-format.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    SharedsModule,
    ReactiveFormsModule
  ],
  declarations: [
    HomePage,
    HomePostComponent,
    HomePostListComponent,
    DateFormatPipe
  ],
})
export class HomePageModule {}
