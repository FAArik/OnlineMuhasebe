import { Injectable } from '@angular/core';
import { ResponseModel } from 'src/app/common/models/response.model';
import { CryptoService } from 'src/app/common/services/crypto.service';
import { GenericHttpService } from 'src/app/common/services/generic-http.service';
import { LoginResponseModel } from '../../auth/models/login-response.model';
import { UcafModel } from '../models/ucaf.model';

@Injectable({
  providedIn: 'root'
})
export class UcafService {
  loginResponse:LoginResponseModel=new LoginResponseModel();
  constructor(
    private _cypto:CryptoService,
    private _http:GenericHttpService
    ) {
      let loginResponseStr=_cypto.decrypt(localStorage.getItem("accessToken").toString());
      this.loginResponse=JSON.parse(loginResponseStr)
     }


  getAll(callback:(res:ResponseModel<UcafModel[]>)=>void){
    let model= {companyId:this.loginResponse.company.companyId}
    this._http.post<ResponseModel<UcafModel[]>>("UCAFs/GetAllUCAF",model,res=>callback(res))
  }
}
