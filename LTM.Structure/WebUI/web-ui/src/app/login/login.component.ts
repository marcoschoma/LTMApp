import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { BaseService } from './../infra/base.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    model: any = {};

    constructor(private loginService: LoginService,
        private router: Router) {
    }

    login() {
        if (this.model.username && this.model.password) {
            this.loginService.login(this.model.username, this.model.password)
                .subscribe(() => {
                    console.log('partiu home');
                    this.router.navigateByUrl('/home');
                });
        }
    }
    ngOnInit() {
        this.loginService.logout();
    }
}
