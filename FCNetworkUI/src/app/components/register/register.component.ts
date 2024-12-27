import {Component, inject, OnInit, signal, WritableSignal} from '@angular/core';
import {Device} from '../../models/interfaces/device/device.interface';
import {DeviceService} from '../../services/device/device.service';
import {NgForOf} from '@angular/common';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {RegisterRequest} from '../../models/interfaces/security/register-request.interface';

@Component({
  selector: 'app-register',
  imports: [
    NgForOf,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {

  devices$ : WritableSignal<Device[]> = signal([]);
  private route: ActivatedRoute = inject(ActivatedRoute);
  registrationInProgress$: WritableSignal<boolean> = signal(false);
  registerForm: FormGroup;

  constructor() {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      passwordConfirm: new FormControl('', [Validators.required, Validators.minLength(6)]),
      platformDeviceID: new FormControl('', [Validators.required]),
      eaAccount: new FormControl('', [Validators.required])
  });

  }

  getDeviceImage(id : string) {
    return this.devices$().find(d => d.id === id)?.name;
  }
  ngOnInit() {
    this.route.data.subscribe((data : any) => {
      if (data['devices']) {
        this.devices$.set(data.devices);
      }
    });
  }

  onSubmit() {
    this.registrationInProgress$.set(true);
    if (this.registerForm.valid) {
      const password = this.registerForm.get('password')?.value;
      const passwordConfirm = this.registerForm.get('passwordConfirm')?.value;
      if(password !== passwordConfirm) {
        this.registrationInProgress$.set(false);
        return;
      }else{
        const registrationPayload : RegisterRequest = this.registerForm.value;
        console.log(registrationPayload);
        this.registrationInProgress$.set(false);
      }
    }else{
      this.registrationInProgress$.set(false);
    }
  }
}
