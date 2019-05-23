import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user-management/user.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  loggedInUser:boolean;

  constructor(private userService:UserService) { }

  ngOnInit() {
    this.loggedInUser = this.userService.securityObject.isAuthenticated;
  }
}
