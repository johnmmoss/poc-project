import { Component, OnInit } from '@angular/core';
import { UserService } from './user-management/user.service';
import { UserAuth } from './user-management/user-auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  roleType:string = null;
  emailAddress:string = null;
  title = 'StatementsTrackerWeb';
  securityObject:UserAuth;

  constructor(
    private userService:UserService,
    private router:Router
  ){
  }

  ngOnInit(): void {
 }

  logOff() {
    console.log("Logging off...")
    this.userService.logOff();
    this.router.navigate(['/home']);
  }

  loggedInUserEmail() {
    return this.userService.securityObject.emailAddress;
  }
  loggedInUser() {
    var isLoggedIn = this.userService.securityObject.isAuthenticated;
    return isLoggedIn ;
  }
}
