import { CanActivate, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AuthService } from "./auth.service";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthActivator implements CanActivate
{
    constructor(private authService:AuthService, private router : Router) {
    
    }
    canActivate(route:ActivatedRouteSnapshot){
        if(!this.authService.isAuthenticated())
        {
            this.router.navigate(['/user/login']);
        }
        return true;
    } 
}