import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {UserRegistration} from '../../models/interfaces/user-registration.interface';
import {Observable} from 'rxjs';
import {Device} from '../../models/interfaces/device/device.interface';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  private http: HttpClient = inject(HttpClient);
  private baseUrl: string = '/api/device';


  public getAll(): Observable<Device[]> {
    return this.http.get<Device[]>(`${this.baseUrl}`);
  }
}
