import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService, ToastrType } from './toastr.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(private _toastr:ToastrService) { }
  errorHandler(err:HttpErrorResponse){
    switch (err.status) {
      case 0:
        this._toastr.toast(ToastrType.Error,"Hata!","Api adresine ulaşılamıyor!")
        break;
      case 404:
        this._toastr.toast(ToastrType.Error,"Hata!","Api adresine bulunamıyor!")
        break;
        case 500:
          if(err.error.Errors){
            let message=JSON.stringify(err.error.Errors)
            this._toastr.toast(ToastrType.Error,"Hata!",message)
          }
          else{
            this._toastr.toast(ToastrType.Error,"Hata!",err.error)
          }
          break;
      default:
        break;
    }
  }
}
