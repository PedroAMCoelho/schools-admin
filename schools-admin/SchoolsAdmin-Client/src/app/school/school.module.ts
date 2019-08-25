import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolListComponent } from './school-list/school-list.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'list', component: SchoolListComponent }
    ])
  ],
  declarations: [SchoolListComponent]
})
export class SchoolModule { }
