import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { BlankComponent } from 'src/app/common/components/blank/blank.component';
import { NavModel } from 'src/app/common/components/blank/models/nav.model';
import { SectionComponent } from 'src/app/common/components/blank/section/section.component';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { ValidInputDirective } from 'src/app/common/directives/valid-input.directive';
import { LoadingButtonComponent } from 'src/app/common/components/loading-button/loading-button.component';
import { ToastrService, ToastrType } from 'src/app/common/services/toastr.service';
import { RemoveByIdUCAFModel } from './models/removeByIdUCAF.model';
import { SwalService } from 'src/app/common/services/swal.service';
import { ExcelLoadingButtonComponent } from 'src/app/common/components/excel-loading-button/excel-loading-button.component';
import { ReportRequestModel } from 'src/app/common/models/report-request.model';
import { ReportService } from '../reports/services/report.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ucaf',
  standalone: true,
  imports: [CommonModule, BlankComponent, SectionComponent, UcafPipe, FormsModule, ValidInputDirective, LoadingButtonComponent, ExcelLoadingButtonComponent],
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
  ucafs: UcafModel[] = [];
  updateModel: UcafModel = new UcafModel();
  ucaftype: string = "M";
  filterText: string = "";
  isAddForm: boolean = false;
  isUpdateForm: boolean = false;

  constructor(
    private _ucafService: UcafService,
    private _toastr: ToastrService,
    private _swal: SwalService,
    private _reportService: ReportService,
    private _router:Router) { }



  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._ucafService.getAll(res => this.ucafs = res.data);
  }

  showAddForm() {
    this.isAddForm = true;
  }

  add(form: NgForm) {
    if (form.valid) {
      let model = new UcafModel();

      model.code = form.controls["code"].value;
      model.type = form.controls["type"].value;
      model.name = form.controls["name"].value;

      this._ucafService.add(model, (res) => {
        form.controls["code"].setValue("");
        form.controls["name"].setValue("");
        this.ucaftype = "M";
        this.getAll();
        this._toastr.toast(ToastrType.Success, "Başarılı!", res.message)
      })
    }
  }

  get(model: UcafModel) {
    this.updateModel = { ...model };
    this.isUpdateForm = true;
    this.isAddForm = false;

  }
  update(form: NgForm) {
    if (form.valid) {

      this._ucafService.update(this.updateModel, (res) => {
        this.cancel();
        this.getAll();
        this._toastr.toast(ToastrType.Info, "Başarılı!", res.message)
      })
    }
  }
  cancel() {
    this.isAddForm = false;
    this.isUpdateForm = false;
  }
  removeById(id: string) {
    this._swal.callSwal("Sil", "Sil?", "Hesap planı kodunu silmek istiyor musunuz?", () => {
      let model = new RemoveByIdUCAFModel();
      model.Id = id;

      this._ucafService.removeById(model, res => {
        this.getAll();
        this._toastr.toast(ToastrType.Info, "Silme Başarılı!", res.message);
      })
    })
  }

  setTrClass(type: string) {
    if (type == "A")
      return "text-danger"
    else if (type == "G")
      return "text-primary"
    else
      return ""
  }

  exportExcel() {
    let model: ReportRequestModel = new ReportRequestModel();
    model.name="Hesap planı"
    this._reportService.request(model,(res)=>{
      this._toastr.toast(ToastrType.Info,"",res.message);
      this._router.navigateByUrl("/reports");
    })
  }
}
