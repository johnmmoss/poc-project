import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { UserService } from '../user-management/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements  CanActivate {

  path: ActivatedRouteSnapshot[];
  route: ActivatedRouteSnapshot;
  
  constructor(
      private userService:UserService,
      private router:Router,
    ){ }
  canActivate(
    next:ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {//: Observable<boolean> | Promise<boolean> {

      let claimType: string = next.data["claimType"] // when we come to check againest claim values...

      if (!this.userService.securityObject.isAuthenticated) {
        this.router.navigate(['login'],
        {
          queryParams: {returnUrl: state.url}
        });
        return false;
      }

      return true;
    }
}
