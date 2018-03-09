import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationResult } from '../model/notification-result';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import { BaseService } from '../base.service';
import { Product } from '../model/product';

@Injectable()
export class ProductService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<Product[]> {
        const url = `${environment.apiUrl}/api/product`;
        return this.http.get<Product[]>(url, { headers: this.getAuthHeaders() });
    }
}
