import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/Observable/ErrorObservable';
import { environment } from './../environments/environment';
import { TokenAuthentication } from './model/token-authentication';

@Injectable()
export class BaseService {

    public urlApi = environment.apiUrl;

    constructor() { }

    /*protected getHeaders(apiVersion = '1.0'): HttpHeaders {
        const headers = new HttpHeaders()
            .set('Accept', 'application/json')
            .set('x-api-version', apiVersion);
        return headers;
    }*/

    protected getAuthHeaders(apiVersion = '1.0'): HttpHeaders {
        const authentication = this.getAuthentication();
        const headers = new HttpHeaders({
            'Accept': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'x-api-version': apiVersion});
        if (authentication) {
            headers.append('Authorization', `Bearer ${authentication.access_token}`);
        }
        console.log('creating headers: ', headers);
        return headers;
    }

    public getAuthentication(): TokenAuthentication {
        const key = 'authentication';
        let authentication: TokenAuthentication = JSON.parse(sessionStorage.getItem(key));

        if (!authentication) {
            authentication = JSON.parse(localStorage.getItem(key));
        }
        console.log('getAuthentication(): ', authentication);
        return authentication;
    }

    protected setAuthentication(authentication: TokenAuthentication, remember: boolean) {
        const key = 'authentication';

        if (remember) {
            localStorage.setItem(key, JSON.stringify(authentication));
        } else {
            sessionStorage.setItem(key, JSON.stringify(authentication));
        }
    }

    public handleError(error): ErrorObservable {
        console.log(error.message);
        throw error;
    }

}
