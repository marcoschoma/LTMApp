import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { BaseService } from './base.service'

export class AddHeaderInterceptor implements HttpInterceptor {
    constructor(private baseService: BaseService) {
    }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const authentication = this.baseService.getAuthentication();

        if (authentication) {
            const clonedRequest = req.clone({ headers: req.headers.set('Authorization', `Bearer ${authentication.access_token}`) });
            return next.handle(clonedRequest);
        }
        return next.handle(req);
    }
}