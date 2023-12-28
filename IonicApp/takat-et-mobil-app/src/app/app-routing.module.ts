import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'place',
    pathMatch: 'full'
  },
  {
    path: 'place',
    loadChildren: () => import('./place/place.module').then( m => m.PlacePageModule)
  },
  {
    path: 'following',
    loadChildren: () => import('./user/following/following.module').then( m => m.FollowingPageModule)
  },
  {
    path: 'following',
    loadChildren: () => import('./profile/following/following.module').then( m => m.FollowingPageModule)
  },
  {
    path: 'search-home',
    loadChildren: () => import('./search/search-home/search-home.module').then( m => m.SearchHomePageModule)
  },
  {
    path: 'search-post-list',
    loadChildren: () => import('./search/search-post-list/search-post-list.module').then( m => m.SearchPostListPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes, {
        preloadingStrategy: PreloadAllModules,
        anchorScrolling : "enabled",
        scrollPositionRestoration: 'enabled'
      }
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
