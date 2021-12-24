import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectsPageComponent } from './subjects-page/subjects-page.component';
import { SubjectItemComponent } from './subject-item/subject-item.component';
import { SubjectsRoutingModule } from './subjects-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SubjectsPageComponent,
    SubjectItemComponent
  ],
  imports: [
    CommonModule,
    SubjectsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    SubjectItemComponent
  ]
})
export class SubjectsModule { }
