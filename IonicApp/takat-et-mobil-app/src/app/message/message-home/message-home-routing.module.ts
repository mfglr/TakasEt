import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MessageHomePage } from './message-home.page';

const routes: Routes = [
  {
    path: '',
    component: MessageHomePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MessageHomePageRoutingModule {}
