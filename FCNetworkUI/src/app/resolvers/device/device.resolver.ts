import { ResolveFn } from '@angular/router';
import {DeviceService} from '../../services/device/device.service';
import {inject} from '@angular/core';
import {Observable} from 'rxjs';
import {Device} from '../../models/interfaces/device/device.interface';

export const deviceResolver: ResolveFn< Observable<Device[]>> = (route, state) => {
  const deviceService: DeviceService = inject(DeviceService);
  return deviceService.getAll();
};
