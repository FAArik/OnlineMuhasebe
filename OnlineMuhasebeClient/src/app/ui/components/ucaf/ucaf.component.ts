import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlankComponent } from 'src/app/common/components/blank/blank.component';
import { NavModel } from 'src/app/common/components/blank/models/nav.model';
import { SectionComponent } from 'src/app/common/components/blank/section/section.component';

@Component({
  selector: 'app-ucaf',
  standalone: true,
  imports: [CommonModule, BlankComponent,SectionComponent],
  templateUrl: './ucaf.component.html',
  styleUrls: ['./ucaf.component.css']
})
export class UcafComponent {
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
}
