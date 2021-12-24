import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserLogin } from 'src/app/shared/models/userLogin';
import { UserSubject } from 'src/app/shared/models/userSubject';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private http: HttpClient,
  ) { }

  // POST /login
  public login(login: string, password: string): Observable<UserLogin> {
    const url = `${environment.urlServer}/login`;
    return this.http.post<UserLogin>(url, { login, password });
  }

  // POST /logout
  public logout() {
    const url = `${environment.urlServer}/logout`;
    return this.http.post<void>(url, {});
  }

   // GET /subjects/user/userId
   public getUserSubject(userId:string): Observable<UserSubject[]> {
    const url = `${environment.urlServer}/subjects/user/${userId}`;
    return this.http.get<UserSubject[]>(url, {});
  }
}