import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'place',
    pathMatch: 'full'
  },
  { path: 'account',loadChildren: () => import('./account/account.module').then( m => m.AccountModule) },
  { path: 'chat',loadChildren: () => import('./chat/chat.module').then( m => m.ChatModule) },
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
