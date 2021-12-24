import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SubjectsPageComponent } from './subjects-page/subjects-page.component';

const routes: Routes = [
    { 
        path: '',
        component: SubjectsPageComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SubjectsRoutingModule { }