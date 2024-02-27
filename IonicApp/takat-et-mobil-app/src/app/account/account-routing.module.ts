import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '',redirectTo : 'login',pathMatch : "full" },
  {
    path: 'login',
    loadChildren: () => import('src/app/account/pages/login/login-page.module').then( m => m.LoginPageModule)
  },
  {
    path: 'sign-up',
    loadChildren: () => import('src/app/account/pages/sign-up/sign-up.module').then( m => m.SignUpPageModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
