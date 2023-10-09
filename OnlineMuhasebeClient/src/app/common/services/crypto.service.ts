import { Injectable } from '@angular/core';

declare var require:any
@Injectable({
  providedIn: 'root'
})
export class CryptoService {

  constructor() { }
  secretKey:string="My name is Fatih132";

  encrypt(value: string): string {
    var CryptoTs = require("crypto-ts");
    return CryptoTs.AES.encrypt(value, this.secretKey);
  }

  decrypt(value: string): string {
    var CryptoTs = require("crypto-ts");
    var bytes = CryptoTs.AES.decrypt(value.toString(), this.secretKey);
    return bytes.toString(CryptoTs.enc.Utf8);
  }
}
