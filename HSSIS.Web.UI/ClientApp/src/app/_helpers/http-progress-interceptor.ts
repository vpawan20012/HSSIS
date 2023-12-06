import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpResponse } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { HttpHandler } from '@angular/common/http';
import { HttpEvent } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { ProgressIndicatorService } from '../services/core-services/progress-indicator-service/progress.indicator.service';


@Injectable()
export class HttpProgressInterceptor implements HttpInterceptor {

    constructor(private progressIndicatorService: ProgressIndicatorService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        this.progressIndicatorService.show();

        return next.handle(req)
            .pipe(tap((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    this.progressIndicatorService.hide();
                }
            }, (error) => {
                this.progressIndicatorService.hide();
            }));
    }
}