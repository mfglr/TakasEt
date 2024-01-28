import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlacePage } from './place.page';

const routes: Routes = [
  {
    path: '',
    component: PlacePage,
    children : [
      { path : '', redirectTo : "home", pathMatch : "full" },
      { path : 'home', loadChildren: () => import('src/app/home/home.module').then( m => m.HomeModule) },
      { path : 'search', loadChildren: () => import('src/app/search/search.module').then( m => m.SearchModule) },
      { path : 'create-post', loadChildren: () => import('./create-post/create-post.module').then( m => m.CreatePostPageModule) },
      { path : 'profile', loadChildren: () => import('src/app/profile/profile.module').then( m => m.ProfileModule ) },
      { path : 'category/:categoryId', loadChildren: () => import('./category/category.module').then( m => m.CategoryPageModule) },
      { path : 'user/:userId', loadChildren : () => import('src/app/user/user.module').then( m => m.UserModule) }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PlacePageRoutingModule {}
