import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo : "home", pathMatch : "full" },
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
    loadChildren : () => import("./create-message/create-message.module").then(m => m.CreateMessagePageModule)
  },
  {
    path : 'conversation',
    loadChildren : () => import("./conversation/conversation.module").then(m => m.ConversationPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MessageRoutingModule {}
