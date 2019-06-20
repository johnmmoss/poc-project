import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user-management/user.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  loggedInUser:boolean;
  roleType:string;
  emailAddress:string;

  constructor(private userService:UserService) { }

  ngOnInit() {
    this.loggedInUser = this.userService.securityObject.isAuthenticated;

    if (this.loggedInUser) {
      // roleType is a string, but roles is either a string or an array depending
      // on if there is multiple roles for this user.
      this.roleType = this.userService.securityObject.roles;
      this.emailAddress = this.userService.securityObject.emailAddress;
    }
  }
}
