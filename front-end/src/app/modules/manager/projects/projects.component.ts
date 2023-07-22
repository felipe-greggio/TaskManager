import { Component, OnInit } from '@angular/core';
import { ProjectService } from './services/project-service.service';
import { Project, ProjectStatus } from 'src/app/shared/Models/Project';
import { FormControl } from '@angular/forms';
import { RegisterTaskDialogComponent } from './register-task-dialog/register-task-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

projectList: Project[] = [];
selectedProject!: any;
projectInfo!: Project;

  constructor(
    public projectService: ProjectService,
    public dialog: MatDialog) {

    this.projectService.getAllProjects().subscribe(projects => {
      this.projectList = projects;
    });
  }


  ngOnInit(): void {
  }

  loadProjectInfo(){
    this.projectService.getProjectInfo(this.selectedProject.projectId).subscribe(response => {
      this.projectInfo = response;
    })
  }

  getProjectStatus(status: ProjectStatus): string {
    return ProjectStatus[status];
  }

  openRegisterTaskDialog(){
    const data = { key: this.projectInfo };
    const dialogRef = this.dialog.open(RegisterTaskDialogComponent, { data });
  }

}
