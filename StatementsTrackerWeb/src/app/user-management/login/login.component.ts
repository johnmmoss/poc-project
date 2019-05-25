import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { UserLogin } from '../user-login';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAuth } from '../user-auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  authFailed:boolean = false;
  userLogin:UserLogin = new UserLogin();
  userResponse:any;

  constructor(
    private userService:UserService,
    private router: Router) 
    { }

  ngOnInit() {
  }

  login(form:NgForm) {

    this.authFailed = false;

    if (form.valid) {
      this.userService.login(this.userLogin).subscribe(
        (securityObject:UserAuth)=> {
          if (securityObject.isAuthenticated) {
            this.router.navigate(['/home']);
          } else {
            this.authFailed = !securityObject.isAuthenticated;
          }
        },
        error => console.log(error)
      );
    }
  }
}
