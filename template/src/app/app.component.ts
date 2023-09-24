import { Component } from '@angular/core';
import { LoggedInUserService } from './services/logged-in-user.service';
import { ContainerName } from './models/containerName';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Template';
  public isLogin : boolean = false;



  constructor(public loggedInUser: LoggedInUserService) {}

  login(event : boolean){
    this.isLogin = event;
  }


}
