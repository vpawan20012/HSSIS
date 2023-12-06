import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from "rxjs";
import { catchError, map } from 'rxjs/operators';
import { ResposneMessageModel } from "../_models/view-models/http-response-view-model";
import { MessageService } from "../services/core-services/message-service/message.service";


@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
    constructor(private messageService: MessageService) { 
        
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(error => {            
            var errorDetails = null;
            if (error.error != null) {
                if (error.error.title != null) {
                    errorDetails = error.error.title;
                    if (error.error.errors != null) {
                        errorDetails = errorDetails + JSON.stringify(error.error.errors);
                    }
                }
                else
                {
                    errorDetails = error.error;                   
                }
            }
            var message: ResposneMessageModel = {
                message: error.message,
                title: 'Error: ' + error.statusText,
                details: errorDetails
            };

            this.messageService.showResponseErrorMessage(message);
            return throwError(error.message);
        }))
    }
}