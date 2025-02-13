import { LoginResponseService } from './../../../../common/services/login-response.service';
import { Injectable } from '@angular/core';

import { MessageResponseModel } from 'src/app/common/models/message-response.model';
import { ResponseModel } from 'src/app/common/models/response.model';
import { CryptoService } from 'src/app/common/services/crypto.service';
import { GenericHttpService } from 'src/app/common/services/generic-http.service';
import { LoginResponseModel } from '../../auth/models/login-response.model';
import { RemoveByIdUCAFModel } from '../models/removeByIdUCAF.model';
import { UcafModel } from '../models/ucaf.model';

@Injectable({
  providedIn: 'root'
})
export class UcafService {
  loginResponse: LoginResponseModel = new LoginResponseModel();
  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) {
    this.loginResponse = this._loginResponse.getLoginResponseModel();
  }


  getAll(callback: (res: ResponseModel<UcafModel[]>) => void) {
    let model = { companyId: this.loginResponse.company.companyId }
    this._http.post<ResponseModel<UcafModel[]>>("UCAFs/GetAllUCAF", model, res => callback(res))
  }
  add(model: UcafModel, callback: (res: MessageResponseModel) => void) {
    model.companyId = this.loginResponse.company.companyId;
    this._http.post<MessageResponseModel>("UCAFs/CreateUCAF", model, (res) => callback(res))
  }
  update(model: UcafModel, callback: (res: MessageResponseModel) => void) {
    model.companyId = this.loginResponse.company.companyId;
    this._http.post<MessageResponseModel>("UCAFs/UpdateUCAF", model, (res) => callback(res))
  }

  removeById(model: RemoveByIdUCAFModel, callback: (res: MessageResponseModel) => void) {
    model.companyId = this.loginResponse.company.companyId;
    this._http.post<MessageResponseModel>("UCAFs/RemoveByIdUCAF", model, (res) => callback(res));
  }
}
