import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.dev';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const loginData = { email, password };
    return this.http.post(`${environment.apiUrl}/auth/login`, loginData);
  }
}
