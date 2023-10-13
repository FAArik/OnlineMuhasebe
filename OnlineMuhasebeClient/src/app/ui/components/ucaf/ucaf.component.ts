import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

import { BlankComponent } from 'src/app/common/components/blank/blank.component';
import { NavModel } from 'src/app/common/components/blank/models/nav.model';
import { SectionComponent } from 'src/app/common/components/blank/section/section.component';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { ValidInputDirective } from 'src/app/common/directives/valid-input.directive';
import { LoadingButtonComponent } from 'src/app/common/components/loading-button/loading-button.component';
import { ToastrService, ToastrType } from 'src/app/common/services/toastr.service';
import { MessageResponseModel } from 'src/app/common/models/Message-response.model';
import { RemoveByIdUCAFModel } from './models/removeByIdUCAF.model';

@Component({
  selector: 'app-ucaf',
  standalone: true,
  imports: [CommonModule, BlankComponent, SectionComponent, UcafPipe, FormsModule, ValidInputDirective, LoadingButtonComponent],
  templateUrl: './ucaf.component.html',
  styleUrls: ['./ucaf.component.css']
})
export class UcafComponent implements OnInit {
  navs: NavModel[] = [
    {
      routerLnk: "/",
      class: "",
      name: "Ana Sayfa"
    },
    {
      routerLnk: "ucas",
      class: "active",
      name: "Hesap planı"
    }
  ]

  constructor(
    private _ucafService: UcafService,
    private _toastr: ToastrService) { }

  filterText: string = "";
  isAddForm: boolean = false;
  ucaftype: string = "M";
  isLoading: boolean = false;

  ngOnInit(): void {
    this.getAll();
  }

  ucafs: UcafModel[] = [];
  getAll() {
    this._ucafService.getAll(res => this.ucafs = res.data);
  }

  showAddForm() {
    this.isAddForm = true;
  }

  add(form: NgForm) {
    if (form.valid) {
      this.isLoading = true;
      let model = new UcafModel();
      console.log(form);

      model.code = form.controls["code"].value;
      model.type = form.controls["type"].value;
      model.name = form.controls["name"].value;

      this._ucafService.add(model, (res) => {
        form.controls["code"].setValue("");
        form.controls["name"].setValue("");
        this.ucaftype = "M";
        this.getAll();
        this.isLoading = false;
        this._toastr.toast(ToastrType.Success, "Başarılı!", res.message)
      })
    }
  }
  cancel() {
    this.isAddForm = false;
  }

  removeById(id: string) {
    var result = confirm("Silme işlemini yapmak istiyor musunuz?");
    if (result) {
      let model = new RemoveByIdUCAFModel();
      model.Id = id;

      this._ucafService.removeById(model, res => {
        this.getAll();
        this._toastr.toast(ToastrType.Info, "Silme Başarılı!", res.message);
      })
    }
  }

  setTrClass(type: string) {
    if (type == "A")
      return "text-danger"
    else if (type == "G")
      return "text-primary"
    else
      return ""
  }
}
