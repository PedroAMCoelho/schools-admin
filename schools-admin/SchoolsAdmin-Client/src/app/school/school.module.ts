import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolListComponent } from './school-list/school-list.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { SchoolCreateComponent } from './school-create/school-create.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component: SchoolListComponent },
      { path: 'create', component: SchoolCreateComponent }
    ])
  ],
  declarations: [SchoolListComponent, SchoolCreateComponent]
})
export class SchoolModule { }
