import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren : () => import('./profile-page/profile-page.module').then( m => m.ProfilePageModule)
  },
  {
    path : 'posts',
    loadChildren : () => import('./profile-posts-page/profile-posts-page.module').then( m => m.ProfilePostsPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProfileRoutingModule {}
