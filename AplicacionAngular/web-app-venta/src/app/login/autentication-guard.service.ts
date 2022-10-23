import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutenticationGuardService implements CanActivate {

  constructor(private router: Router) { }
  canActivate() {
    if(sessionStorage.getItem("token")!=null) 
    {
        console.log("token:",sessionStorage.getItem("token"));
        return true;
    }
    else{
      console.log("no hay token");
      this.router.navigate(['/mlogin']);
      return false;
    }
  }
}
