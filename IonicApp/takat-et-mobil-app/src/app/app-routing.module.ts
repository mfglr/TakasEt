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
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules,anchorScrolling : "enabled"})
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
