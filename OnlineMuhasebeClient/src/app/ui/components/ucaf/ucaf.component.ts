import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlankComponent } from 'src/app/common/components/blank/blank.component';
import { NavModel } from 'src/app/common/components/blank/models/nav.model';
import { SectionComponent } from 'src/app/common/components/blank/section/section.component';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ucaf',
  standalone: true,
  imports: [CommonModule,BlankComponent,SectionComponent,UcafPipe,FormsModule],
  templateUrl: './ucaf.component.html',
  styleUrls: ['./ucaf.component.css']
})
export class UcafComponent implements OnInit{
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

  constructor(private _ucafService:UcafService){}

  filterText:string="";

  ngOnInit(): void {
    this.getAll();
  }

  ucafs:UcafModel[]=[];
  getAll(){
    this._ucafService.getAll(res=>this.ucafs=res.data);
  }
}
