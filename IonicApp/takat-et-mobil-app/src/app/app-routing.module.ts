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
    path: 'create-message',
    loadChildren: () => import('./message/create-message/create-message.module').then( m => m.CreateMessagePageModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./home/home/home.module').then( m => m.HomePageModule)
  },
  {
    path: 'create-story',
    loadChildren: () => import('./home/create-story/create-story.module').then( m => m.CreateStoryPageModule)
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
