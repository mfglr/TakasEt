import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren : () => import('./message-home/message-home.module').then( m => m.MessageHomePageModule)
  },
  {
    path: 'home',
    loadChildren : () => import("./message-home/message-home.module").then(m => m.MessageHomePageModule)
  },
  {
    path: 'search',
    loadChildren : () => import("./search-message/search-message.module").then(m => m.SearchMessagePageModule)
  },
  {
    path : 'create',
    loadChildren : () => import("./create-message/create-message-routing.module").then(m => m.CreateMessagePageRoutingModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MessageRoutingModule {}
