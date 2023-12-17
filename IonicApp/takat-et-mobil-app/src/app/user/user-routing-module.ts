import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren : () => import('./user-page/user-page.module').then( m => m.UserPageModule)
  },
  {
    path : 'posts',
    loadChildren : () => import('./user-posts-page/user-posts-page.module').then( m => m.UserPostsPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
