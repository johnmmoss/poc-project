import { Injectable, NgModule } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor() {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        var accessToken = localStorage.getItem("accessToken")

        if (accessToken) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${accessToken}`
                }
            });
        }

        return next.handle(request);
    }
}


@NgModule({
    providers: [
        { 
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        }
    ]
})
export class JwtInterceptorModule {}