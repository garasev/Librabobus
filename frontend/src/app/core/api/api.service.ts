import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserLogin } from 'src/app/shared/models/userLogin';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private http: HttpClient,
  ) { }

  // POST /api/auth/login
  public login(login: string, password: string): Observable<UserLogin> {
    const url = `${environment.urlServer}/api/auth/login`;
    return this.http.post<UserLogin>(url, { login, password });
  }

  // POST /api/auth/logout
  public logout() {
    const url = `${environment.urlServer}/api/auth/login`;
    return this.http.post<void>(url, {});
  }
}