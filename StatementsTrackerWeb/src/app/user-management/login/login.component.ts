import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { UserLogin } from '../user-login';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserAuth } from '../user-auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  returnUrl:string=null;
  authFailed:boolean = false;
  userLogin:UserLogin = new UserLogin();
  userResponse:any;

  constructor(
    private userService:UserService,
    private route:ActivatedRoute,
    private router: Router) 
    { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
  }

  login(form:NgForm) {

    this.authFailed = false;

    if (form.valid) {
      this.userService.login(this.userLogin).subscribe(
        (securityObject:UserAuth)=> {
          if (securityObject.isAuthenticated) { // i.e. We have logged in successfully
            if(this.returnUrl) {
              this.router.navigateByUrl(this.returnUrl);
            } else { 
              this.router.navigate(['/home']);
            }
          } else { // Login failed :(
            this.authFailed = !securityObject.isAuthenticated;
          }
        },
        error => console.log(error)
      );
    }
  }
}
