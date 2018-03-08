import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { BaseService } from '../base.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router,
        private service: BaseService) { }

    canActivate() {
        const authToken = this.service.getAuthentication();
        if (authToken && authToken.id_token) {
            return true;
        }

        // not logged in so redirect to login page
        this.router.navigate(['/login']);
        return false;
    }
}
