import { Injectable } from '@angular/core';
import { LoginResponseModel } from 'src/app/ui/components/auth/models/login-response.model';
import { CryptoService } from './crypto.service';

@Injectable({
  providedIn: 'root'
})
export class LoginResponseService {

  loginResponse: LoginResponseModel = new LoginResponseModel();

  constructor(
    private _cypto: CryptoService,
  ) {
    
  }
  getLoginResponseModel() {
    let token = localStorage.getItem("accessToken")?.toString()
    if (token != undefined) {
      let loginResponseStr = this._cypto.decrypt(token);
      this.loginResponse = JSON.parse(loginResponseStr)
    }
    return this.loginResponse;
  }
}
