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
        loadChildren: () => import('./search/search.module').then( m => m.SearchPageModule)
      },
    ]
  },
  
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PlacePageRoutingModule {}
