import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ApiService } from 'src/app/core/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly ACCESS_TOKEN_KEY = 'accessToken';
  private readonly USER_LOGIN_KEY = 'userLogin';

  private userLoginBehaviorSubject = new BehaviorSubject<string | null>(null);
  public userLoginObservable = this.userLoginBehaviorSubject.asObservable();

  public get userLogin() {
    return this.userLoginBehaviorSubject.value;
  }

  public set userLogin(login: string | null) {
    this.userLoginBehaviorSubject.next(login);
  }

  private accessTokenBehaviorSubject = new BehaviorSubject<string | null>(null);
  public accessTokenObservable = this.accessTokenBehaviorSubject.asObservable();

  public get accessToken() {
    return this.accessTokenBehaviorSubject.value;
  }

  public set accessToken(token: string | null) {
    this.accessTokenBehaviorSubject.next(token);
  }

  constructor(
    private router: Router,
    private readonly api: ApiService,
  ) {
    const token = localStorage.getItem(this.ACCESS_TOKEN_KEY);
    const userLogin = localStorage.getItem(this.USER_LOGIN_KEY);

    if (token) {
      this.accessToken = token;
    }

    if (userLogin) {
      this.userLogin = userLogin;
    }
  }

  public async login(login: string, password: string) {
    try {
      const resp = await this.api.login(login, password).toPromise();

      localStorage.setItem(this.ACCESS_TOKEN_KEY, resp.access_token);
      localStorage.setItem(this.USER_LOGIN_KEY, resp.id);

      this.accessToken = resp.access_token;
      this.userLogin = resp.id;


      this.router.navigate(['profile']);
    } catch (error) {
      if (error instanceof HttpErrorResponse
          && error.status === 401) {
              console.log('dolboeb');
       // this.notifications.showSnackBar('Ошибка: неверно введён логин или пароль');
      }
    }
  }

  public async logout() {
   // await this.api.logout();
    this.removeTokens();
    this.router.navigate(['auth']);
  }

  public isAuthed(): boolean {
    return localStorage.getItem(this.ACCESS_TOKEN_KEY) !== null;
  }

  public removeTokens() {
    localStorage.removeItem(this.ACCESS_TOKEN_KEY);
    localStorage.removeItem(this.USER_LOGIN_KEY);
    this.accessToken = null;
  }

}