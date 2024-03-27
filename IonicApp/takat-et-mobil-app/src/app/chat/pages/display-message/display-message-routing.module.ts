import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DisplayMessagePage } from './display-message.page';

const routes: Routes = [
  {
    path: '',
    component: DisplayMessagePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DisplayMessagePageRoutingModule {}
