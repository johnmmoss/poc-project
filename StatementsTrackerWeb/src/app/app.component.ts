import { Component } from '@angular/core';
import { UserService } from './user-management/user.service';
import { UserAuth } from './user-management/user-auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StatementsTrackerWeb';
  securityObject:UserAuth;

  constructor(
    private userService:UserService,
    private router:Router
  ){
    console.log(userService.securityObject);
    this.securityObject = userService.securityObject;
  }


  logOff() {
    this.userService.logOff();
    this.router.navigate(['/home']);
  }
}
