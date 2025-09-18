import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { jwtDecode } from 'jwt-decode'; // Asegúrate de instalar esta librería
import { LoginDto, RegisterDto } from '../interfaces/auth.dto'; // DTOs que coinciden con tu API

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7064/api/Auth'; // URL de tu API
  private tokenKey = 'jwtToken'; // Clave para el almacenamiento local

  // Sujeto para emitir el estado de autenticación
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(this.hasToken());

  constructor(private http: HttpClient, private router: Router) { }

  // 1. Métodos de Autenticación
  login(loginDto: LoginDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, loginDto).pipe(
      map(response => {
        const token = response.token;
        if (token) {
          localStorage.setItem(this.tokenKey, token);
          this.isAuthenticatedSubject.next(true);
        }
        return response;
      }),
      catchError(this.handleError)
    );
  }

  register(registerDto: RegisterDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, registerDto).pipe(
      catchError(this.handleError)
    );
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.isAuthenticatedSubject.next(false);
    this.router.navigate(['/login']);
  }

  // 2. Métodos de Verificación de Estado
  isLoggedIn(): boolean {
    const token = this.getToken();
    return !!token && !this.isTokenExpired(token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUserRole(): string {
    const token = this.getToken();
    if (token) {
      try {
        const decodedToken: any = jwtDecode(token);
        return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      } catch (error) {
        console.error('Error decodificando el token:', error);
      }
    }
    return '';
  }

  isTokenExpired(token: string): boolean {
    const decodedToken: any = jwtDecode(token);
    const expirationDate = decodedToken.exp;
    const now = Math.floor(Date.now() / 1000);
    return now > expirationDate;
  }
  
  // 3. Método para manejar errores
  private handleError(error: any): Observable<never> {
    console.error('An error occurred:', error.error.error);
    return throwError(() => new Error(error.error.error || 'Something went wrong.'));
  }

  private hasToken(): boolean {
    const token = this.getToken();
    return !!token;
  }
}