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
  ) { }

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

      // Fudge these for now
      this.securityObject.canAddUsers = true;
      this.securityObject.canAddStatements = true;

      localStorage.setItem("accessToken", token);
    }
  }

  resetSecurityObject(): void {
    this.securityObject.emailAddress = "";
    this.securityObject.accessToken = "";
    this.securityObject.isAuthenticated = false;

    this.securityObject.canAddStatements = false;
    this.securityObject.canAddUsers = false;

    localStorage.removeItem("accessToken");
  }
}
