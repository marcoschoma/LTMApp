import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationResult } from '../model/notification-result';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import { BaseService } from '../infra/base.service';

@Injectable()
export class ProductService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<NotificationResult> {
        const url = `${environment.apiUrl}/api/product`;
        const getProducts$ = this.http.get<NotificationResult>(url, { headers: this.getAuthHeaders() });
        getProducts$.subscribe((result) => {
            console.log(result);
        });
        return getProducts$;
    }
}
