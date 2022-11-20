import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable, tap } from "rxjs";
import { API_URL } from "../app-injection-tokens";
import { Token } from "../models/token";

export const ACCESS_TOKEN_KEY = "acess_token";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(
    private http: HttpClient,
    @Inject(API_URL) private apiUrl: string,
    private jwtHelper: JwtHelperService,
    private router: Router
  ) {}

  login(userName: string, password: string): Observable<Token> {
    return this.http
      .post<Token>(`${this.apiUrl}/api/account/login`, { userName, password })
      .pipe(
        tap((token) => {
          localStorage.setItem(ACCESS_TOKEN_KEY, token.accessToken);
        })
      );
  }

  isAuthenticated(): boolean {
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  logout(): void {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate([""]);
  }
}
