import { Routes } from '@angular/router';
import {LoginComponent} from './app/components/login/login.component';
import {RegisterComponent} from './app/components/register/register.component';
import {deviceResolver} from './app/resolvers/device/device.resolver';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent, title: 'Connexion' },
  { path: 'register', component: RegisterComponent, title: 'Inscription', resolve: { devices: deviceResolver } },
];
