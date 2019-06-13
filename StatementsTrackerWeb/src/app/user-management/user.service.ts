import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLogin } from './user-login';
import { UserAuth } from './user-auth';
import { Observable, of } from 'rxjs';
import { UserLoginResponse } from './user-login-response';
import { map } from "rxjs/operators"
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  securityObject: UserAuth = new UserAuth();
  userLoginResponse: UserLoginResponse;

  constructor(
    private httpClient: HttpClient
  ) { 

    var rawToken = localStorage.getItem("accessToken")
    this.buildSecurityObject(rawToken);
    console.log("rawToken:" + rawToken);
  }

  login(userLogin: UserLogin): Observable<UserAuth> {

    this.resetSecurityObject();

    let url = 'http://localhost/StatementsTracker.Api/api/accounts/signin'

    return this.httpClient.post<UserLoginResponse>(url, userLogin).pipe(
      map(
        userLoginResponse => {
          this.resetSecurityObject();
          this.buildSecurityObject(userLoginResponse.token);

          return this.securityObject;
        }
      )
    );
  }

  buildSecurityObject(token:string) {

    const jwtHelperService = new JwtHelperService();
    const decodedToken = jwtHelperService.decodeToken(token);

    this.securityObject.isAuthenticated = decodedToken != null; 

    if (this.securityObject.isAuthenticated) {

      this.securityObject.emailAddress = decodedToken.sub;
      this.securityObject.accessToken = token;
      this.securityObject.roles = decodedToken.role;

      localStorage.setItem("accessToken", token);
    }
  }

  resetSecurityObject(): void {
    this.securityObject.emailAddress = "";
    this.securityObject.accessToken = "";
    this.securityObject.isAuthenticated = false;

    this.securityObject.roles = [];

    localStorage.removeItem("accessToken");
  }

  logOff(): void {
    this.resetSecurityObject();
  }

  hasRole(roleValue: string) {
    return this.isRoleValid(roleValue); 
  }

  private isRoleValid(roleValue:string) {
    let auth:UserAuth=null;
    auth = this.securityObject;

    if (auth) {
      return auth.roles.find(r => r.toLowerCase() == roleValue.toLowerCase());
    }
    return false;
  }
}
