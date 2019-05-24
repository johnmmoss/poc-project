import { Component } from '@angular/core';
import { UserService } from './user-management/user.service';
import { UserAuth } from './user-management/user-auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StatementsTrackerWeb';
  securityObject:UserAuth;

  constructor(
    private userService:UserService
  ){
    console.log(userService.securityObject);
    this.securityObject = userService.securityObject;
  }
}
