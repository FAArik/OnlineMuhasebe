import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

import { Navigations } from './../../../router/navbar.navigation';
import { LoginResponseModel } from '../../auth/models/login-response.model';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-aside',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.css']
})
export class AsideComponent {
@Input() loginResponse :LoginResponseModel =new LoginResponseModel();

navigations=Navigations;

constructor(private _auth:AuthService){}

logout(){
  this._auth.logout();
}
}
