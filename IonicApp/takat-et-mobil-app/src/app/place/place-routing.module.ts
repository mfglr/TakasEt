import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlacePage } from './place.page';

const routes: Routes = [
  {
    path: '',
    component: PlacePage,
    children : [
      {
        path: '',
        loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
      },
      {
        path: 'home',
        loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
      },
      {
        path: 'search',
        loadChildren: () => import('src/app/search/search.module').then( m => m.SearchModule)
      },
      {
        path: 'create-post',
        loadChildren: () => import('./create-post/create-post.module').then( m => m.CreatePostPageModule)
      },
      {
        path: 'messages',
        loadChildren: () => import('src/app/message/message.module').then( m => m.MessageModule)
      },
      {
        path: 'profile',
        loadChildren: () => import('src/app/profile/profile.module').then( m => m.ProfileModule )
      },
      {
        path: 'explore',
        loadChildren: () => import('./explore/explore.module').then( m => m.ExplorePageModule)
      },
      {
        path: 'category/:categoryId',
        loadChildren: () => import('./category/category.module').then( m => m.CategoryPageModule)
      },
      {
        path : 'user/:userId',
        loadChildren : () => import('src/app/user/user.module').then( m => m.UserModule)
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PlacePageRoutingModule {}
