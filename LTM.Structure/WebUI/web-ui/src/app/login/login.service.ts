import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as moment from 'moment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/takeUntil';
import 'rxjs/add/operator/catch';

import { User } from './../model/user';
import { environment } from '../../environments/environment';
import { NotificationResult } from '../model/notification-result';
import { BaseService } from '../base.service';
import { TokenAuthentication } from '../model/token-authentication';
import { Subject } from 'rxjs/Subject';
import { Router } from '@angular/router';

@Injectable()
export class LoginService extends BaseService {
  private ngUnsubscribe: Subject<void>;

  constructor(private httpClient: HttpClient,
    private router: Router) {
    super();
  }

  logout() {
    const key = 'authentication';
    localStorage.removeItem(key);
    sessionStorage.removeItem(key);
    this.router.navigate(['/']);
  }

  getToken(): any {
    return localStorage.getItem('id_token');
  }

  login(username: string, password: string): Observable<NotificationResult> {
    const data = { Username: username, Password: password };
    const url = `${environment.apiUrl}/api/Account/login`;
    const login$ = this.httpClient.post<NotificationResult>(url, data, { headers: this.getAuthHeaders() });
    login$.subscribe((result) => {
      console.log('resultado: ', result);
      this.authentication(result, true);
    });
    return login$;
  }

  private refreshTokens(): void {
    const url = `${environment.apiUrl}/api/Account/refreshToken`;
    const authentication = super.getAuthentication();
    const data = { refresh_token: authentication.refresh_token };
    this.httpClient.post<NotificationResult>(url, data, { headers: this.getAuthHeaders() })
      .catch(err => this.handleError(err))
      .takeUntil(this.ngUnsubscribe)
      .subscribe(result => {
        this.authentication(result, authentication.remember);
      });
  }

  private scheduleRefreshToken(expires_in: number): void {
    const interval = (expires_in / 2) * 1000;
    setTimeout(() => {
      this.refreshTokens();
    }, interval);
  }

  private authentication(result: NotificationResult, remember: boolean): void {
    console.log('called authentication: ', result);
    if (result.isValid) {
      const authentication = result.data as TokenAuthentication;
      const now = new Date();
      authentication.expiration_date = new Date(now.getTime() + authentication.expires_in * 1000).getTime().toString();
      authentication.remember = remember;
//      this.authenticated = true;
      super.setAuthentication(authentication, remember);
      this.scheduleRefreshToken(authentication.expires_in);
      console.log('get auth: ', super.getAuthentication());
    }
  }
}
