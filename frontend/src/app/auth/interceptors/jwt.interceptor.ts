import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private auth: AuthService,
    private router: Router,
  ) {}

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    const accessToken = this.auth.accessToken;

    if (accessToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`
        }
      });
    }

    return next.handle(request).pipe(
      catchError(error => {
        if (error.status === 401 || error.status === 403) {
          this.router.navigate(['auth']);
          this.auth.removeTokens();
        }
        return throwError(error);
      })
    );
  }

}