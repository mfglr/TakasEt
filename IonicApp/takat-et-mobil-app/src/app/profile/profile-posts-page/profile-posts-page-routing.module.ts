import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfilePostsPage } from './profile-posts.page';

const routes: Routes = [
  {
    path: '',
    component: ProfilePostsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProfilePostsPageRoutingModule {}
