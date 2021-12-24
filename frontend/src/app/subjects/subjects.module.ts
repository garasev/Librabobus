import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectsPageComponent } from './subjects-page/subjects-page.component';
import { SubjectItemComponent } from './subject-item/subject-item.component';
import { SubjectsRoutingModule } from './subjects-routing.module';



@NgModule({
  declarations: [
    SubjectsPageComponent,
    SubjectItemComponent
  ],
  imports: [
    CommonModule,
    SubjectsRoutingModule,
  ],
  exports: [
    SubjectItemComponent
  ]
})
export class SubjectsModule { }
