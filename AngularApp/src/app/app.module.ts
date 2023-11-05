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
import { userReducer } from './states/user/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserEffect } from './states/user/effect';
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
import { PostListComponent } from './shareds/post-list/post-list.component';
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
import { PostComponent } from './shareds/post-list/post/post.component';
import { PostHeaderComponent } from './shareds/post-list/post-header/post-header.component';
import { PostFooterComponent } from './shareds/post-list/post-footer/post-footer.component';
import { CommentModalComponent } from './modals/comment-modal/comment-modal.component';
import { CommentItemComponent } from './modals/comment-modal/comment-item/comment-item.component';
import { CommentItemContentComponent } from './modals/comment-modal/comment-item-content/comment-item-content.component';
import { DateFormatPipe } from './pipes/date-format.pipe';
import { UsersListModalComponent } from './modals/users-list-modal/users-list-modal.component';
import { UserItemComponent } from './modals/users-list-modal/user-item/user-item.component';
import { PostDetailModalComponent } from './modals/post-detail-modal/post-detail-modal.component';
import { appPostReducer } from './states/post_state/reducer';
import { AppPostsEffect } from './states/post_state/effect';

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
    PostListComponent,
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
    PostComponent,
    PostHeaderComponent,
    PostFooterComponent,
    CommentModalComponent,
    CommentItemComponent,
    CommentItemContentComponent,
    DateFormatPipe,
    UsersListModalComponent,
    UserItemComponent,
    PostDetailModalComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(),
    StoreModule.forFeature("userStoreSlice" , userReducer),
    StoreModule.forFeature("AppPostState", appPostReducer),
    EffectsModule.forRoot(),
    EffectsModule.forFeature([UserEffect]),
    EffectsModule.forFeature([AppPostsEffect])
  ],
  providers: [AppHubConnectionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
