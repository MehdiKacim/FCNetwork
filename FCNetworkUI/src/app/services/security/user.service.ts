import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {UserRegistration} from '../../models/interfaces/user-registration.interface';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http: HttpClient = inject(HttpClient);
  private baseUrl: string = '/api/user';


  public register(userRegistration: UserRegistration): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/register`, userRegistration);
  }
}
