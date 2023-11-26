import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoadFilesComponent } from './shareds/load-files/load-files.component';
import { CategoryInputComponent } from './shareds/category-input/category-input.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { DisplayPostImagesComponent } from './modals/post-detail-modal/display-post-images/display-post-images.component';
import { DisplayProfileImageComponent } from './shareds/display-profile-image/display-profile-image.component';
import { AppHubConnectionService } from './services/app-hub-connection.service';
import { DisplayPostContentComponent } from './modals/post-detail-modal/display-post-content/display-post-content.component';
import { LikeButtonComponent } from './shareds/like-button/like-button.component';
import { SwapRequestComponent } from './modals/swap-request/swap-request.component';
import { SwapRequestItemComponent } from './modals/swap-request/swap-request-item/swap-request-item.component';
import { ProfileHeaderComponent } from './pages/profile/profile-header/profile-header.component';
import { ProfileContentComponent } from './pages/profile/profile-content/profile-content.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { FollowButtonComponent } from './shareds/follow-button/follow-button.component';
import { HomeComponent } from './pages/home/home.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { AppLayoutHeaderComponent } from './layouts/app-layout-header/app-layout-header.component';
import { SearchComponent } from './pages/search/search.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { SwapProposalsComponent } from './pages/profile/swap-proposals/swap-proposals.component';
import { SwapRequestsComponent } from './pages/profile/swap-requests/swap-requests.component';
import { FollowedPostsComponent } from './pages/profile/followed-posts/followed-posts.component';
import { CommentModalComponent } from './modals/comment-modal/comment-modal.component';
import { CommentItemComponent } from './modals/comment-modal/comment-item/comment-item.component';
import { CommentItemContentComponent } from './modals/comment-modal/comment-item-content/comment-item-content.component';
import { DateFormatPipe } from './pipes/date-format.pipe';
import { UsersListModalComponent } from './modals/users-list-modal/users-list-modal.component';
import { UserItemComponent } from './modals/users-list-modal/user-item/user-item.component';
import { PostDetailModalComponent } from './modals/post-detail-modal/post-detail-modal.component';
import { appLoginReducer } from './states/login_state/reducer';
import { AppLoginEffect } from './states/login_state/effect';
import { commentModalCollectionReducer } from './states/comment_modal_state/reducer';
import { CommentModalCollectionEffect } from './states/comment_modal_state/effect';
import { HomePostListComponent } from './pages/home/post-list/post-list.component';
import { HomePostComponent } from './pages/home/post-list/post/post.component';
import { PostImageSliderComponent } from './shareds/post-image-slider/post-image-slider.component';
import { HomePostHeaderComponent } from './pages/home/post-list/post-header/post-header.component';
import { HomePostFooterComponent } from './pages/home/post-list/post-footer/post-footer.component';
import { pagePostReducer } from './states/post-state/reducer';
import { PagePostEffect } from './states/post-state/effect';
import { PostComponent } from './shareds/post-list/post/post.component';
import { PostListComponent } from './shareds/post-list/post-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoadFilesComponent,
    CategoryInputComponent,
    CreatePostComponent,
    DisplayPostImagesComponent,
    DisplayProfileImageComponent,
    DisplayPostContentComponent,
    LikeButtonComponent,
    SwapRequestComponent,
    SwapRequestItemComponent,
    ProfileHeaderComponent,
    ProfileContentComponent,
    ProfileComponent,
    HomePostListComponent,
    FollowButtonComponent,
    HomeComponent,
    AppLayoutComponent,
    AppLayoutHeaderComponent,
    SearchComponent,
    MessagesComponent,
    NotificationsComponent,
    SwapProposalsComponent,
    SwapRequestsComponent,
    FollowedPostsComponent,
    HomePostComponent,
    HomePostHeaderComponent,
    HomePostFooterComponent,
    CommentModalComponent,
    CommentItemComponent,
    CommentItemContentComponent,
    DateFormatPipe,
    UsersListModalComponent,
    UserItemComponent,
    PostDetailModalComponent,
    PostImageSliderComponent,
    PostComponent,
    PostListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(),
    StoreModule.forFeature("AppLoginState", appLoginReducer),
    StoreModule.forFeature("CommentModalStateCollection", commentModalCollectionReducer),
    StoreModule.forFeature("PagePostStore",pagePostReducer),
    EffectsModule.forRoot(),
    EffectsModule.forFeature([AppLoginEffect]),
    EffectsModule.forFeature([CommentModalCollectionEffect]),
    EffectsModule.forFeature([PagePostEffect])

  ],
  providers: [AppHubConnectionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
