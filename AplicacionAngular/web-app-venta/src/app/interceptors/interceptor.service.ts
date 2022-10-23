import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
     console.log("Paso por el interceptor");
     const tokenrizeReq=req.clone({
      setHeaders:{
        Authorization: `Bearer ${sessionStorage.getItem("token")}`
      }
     });
     return next.handle(tokenrizeReq).pipe(catchError(this.manejarError))
  }
  manejarError(error:HttpErrorResponse){
     console.log("sucedio un error: ",error);
     return throwError("Error personalizado");
  }
}
