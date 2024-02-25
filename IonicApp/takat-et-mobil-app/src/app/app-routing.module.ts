import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'place',
    pathMatch: 'full'
  },
  { path: 'place', loadChildren: () => import('./place/place.module').then( m => m.PlacePageModule) },
  { path : 'messages', loadChildren: () => import('src/app/message/message.module').then( m => m.MessageModule) },
  { path: 'login',loadChildren: () => import('./login/login.module').then( m => m.LoginModule) },
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
