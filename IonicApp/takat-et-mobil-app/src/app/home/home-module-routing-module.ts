import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren : () => import('./home/home.module').then( m => m.HomePageModule)
  },
  {
    path: 'create-story',
    loadChildren : () => import('./create-story/create-story.module').then( m => m.CreateStoryPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeModuleRoutingModule {}
