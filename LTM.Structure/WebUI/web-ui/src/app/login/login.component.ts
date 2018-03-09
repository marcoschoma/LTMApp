import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { BaseService } from '../base.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    model: any = {};
    isLoading = false;

    constructor(private loginService: LoginService,
        private router: Router) {
    }

    login() {
        if (this.model.username && this.model.password) {
            this.loginService.login(this.model.username, this.model.password)
                .subscribe(() => {
                    this.isLoading = true;
                    this.router.navigateByUrl('/home');
                });
        }
    }
    ngOnInit() {
        this.loginService.logout();
    }
}
