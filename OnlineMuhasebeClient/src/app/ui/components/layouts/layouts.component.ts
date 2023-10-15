import { RouterModule } from '@angular/router';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CryptoService } from 'src/app/common/services/crypto.service';
import { LoginResponseModel } from '../auth/models/login-response.model';
import { NavbarComponent } from './navbar/navbar.component';
import { AsideComponent } from './aside/aside.component';
import { FooterComponent } from './footer/footer.component';
import { ControlSidebarComponent } from './control-sidebar/control-sidebar.component';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [CommonModule, RouterModule, NavbarComponent, AsideComponent,FooterComponent,ControlSidebarComponent],
  templateUrl: './layouts.component.html',
  styleUrls: ['./layouts.component.css']
})
export class LayoutsComponent {
  
  loginResponse:LoginResponseModel=new LoginResponseModel();
  constructor(private _crypto:CryptoService){
    let loginResponseString=_crypto.decrypt(localStorage.getItem("accessToken").toString());
    this.loginResponse=JSON.parse(loginResponseString);
    console.log(this.loginResponse);
  }

  
}
