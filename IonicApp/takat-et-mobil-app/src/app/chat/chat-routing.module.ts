import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path : '', redirectTo : 'home',pathMatch : 'full' },
  {
    path: 'home',
    loadChildren : () => import("src/app/chat/pages/chat-home/chat-home.module").then(m => m.ChatHomePageModule)
  },
  {
    path : "conversation",
    loadChildren : () => import("src/app/chat/pages/conversation/conversation.module").then(m => m.ConversationPageModule)
  },
  {
    path: 'create-conversation',
    loadChildren: () => import('./pages/create-conversation/create-conversation.module').then( m => m.CreateConversationPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChatRoutingModule {}
