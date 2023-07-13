import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ManagerRoutingModule } from './manager-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { RegisterProjectDialogComponent } from './projects/register-project-dialog/register-project-dialog.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    ProjectsComponent,
    RegisterProjectDialogComponent
  ],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    SharedModule
  ],
  exports:[RegisterProjectDialogComponent]
})
export class ManagerModule { }
