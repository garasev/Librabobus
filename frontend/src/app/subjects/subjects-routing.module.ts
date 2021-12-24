import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SubjectComponent } from './subject/subject.component';
import { SubjectsPageComponent } from './subjects-page/subjects-page.component';

const routes: Routes = [
    { 
        path: '',
        component: SubjectsPageComponent,
    },
    {
        path: ':id',
        component: SubjectComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SubjectsRoutingModule { }