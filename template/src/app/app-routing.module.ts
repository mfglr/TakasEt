import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './pages/profile/profile.component';
import { DisplayPostContentComponent } from './pages/display-post-page/display-post-content/display-post-content.component';

const routes: Routes = [
  {path : 'profile',component : ProfileComponent},
  {path : 'profile/:id',component : ProfileComponent},
  {path : 'diplay-post',component : DisplayPostContentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
