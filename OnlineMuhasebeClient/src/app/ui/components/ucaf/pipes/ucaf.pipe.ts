import { Pipe, PipeTransform } from '@angular/core';
import { StringService } from 'src/app/common/services/string.service';

@Pipe({
  name: 'ucafPipe',
  standalone: true
})
export class UcafPipe implements PipeTransform {

  constructor(private _string: StringService) { }

  transform(value: any[], filterText: string): any[] {
    if (filterText == "") {
      return value;
    }

    return value.filter(p => {
      const code = this._string.trLowerCase(p.code).includes(this._string.trLowerCase(filterText));
      const name = p.name.toLowerCase().includes(this._string.trLowerCase(filterText));
      return code + name;
    });
  }

}
