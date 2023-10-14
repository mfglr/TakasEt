import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './pages/profile/profile.component';
import { HomeComponent } from './pages/home/home.component';
import { DisplayPostPageComponent } from './pages/display-post-page/display-post-page.component';
import { SearchComponent } from './pages/search/search.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { SwapProposalsComponent } from './pages/profile/swap-proposals/swap-proposals.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';

const routes: Routes = [
  {
    path : '', component : AppLayoutComponent,
    children : [
      {path : '',component : HomeComponent},
      {path : 'home',component : HomeComponent},
      {path : 'search',component : SearchComponent},
      {path : 'create-post',component : CreatePostComponent},
      {path : 'messages',component : MessagesComponent},
      {path : 'notifications',component : NotificationsComponent},
      {
        path : 'profile', component : ProfileComponent,
        children : [
          {path : 'swap-propasals', component : SwapProposalsComponent},
          {path : 'swap-requests', component : SwapProposalsComponent},
          {path : 'followed-posts', component : SwapProposalsComponent},
        ]
      },
      {path : 'user/:id',component : ProfileComponent},
      {path : 'display-post/:id',component : DisplayPostPageComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
