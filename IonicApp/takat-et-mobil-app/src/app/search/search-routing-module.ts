import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren : () => import('./search-home/search-home.module').then( m => m.SearchHomePageModule)
  },
  {
    path: 'post-list/:postId',
    loadChildren : () => import("./search-post-list/search-post-list.module").then(m => m.SearchPostListPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SearchRoutingModule {}
