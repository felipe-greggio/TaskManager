import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ProjectService } from '../services/project-service.service';
import { Project } from 'src/app/shared/Models/Project';

@Component({
  selector: 'app-register-project-dialog',
  templateUrl: './register-project-dialog.component.html',
  styleUrls: ['./register-project-dialog.component.css']
})
export class RegisterProjectDialogComponent implements OnInit {

registerProjectForm!: FormGroup;
newProject: Project = {};

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<RegisterProjectDialogComponent>,
    public projectService: ProjectService
  ) { }

  ngOnInit(): void {
    this.registerProjectForm = this.formBuilder.group({
      name:[''],
      startDate:[''],
      endDate:['']
    });
  }



  cancelClick(): void {
    this.dialogRef.close();
    this.registerProjectForm.reset();
  }

  registerNewProject(){
    var confirmation = window.confirm("Are you sure you want to register a new project?");
    if(confirmation){
      this.newProject.name = this.registerProjectForm.value.name;
      this.newProject.startDate = this.registerProjectForm.value.startDate;
      this.newProject.endDate = this.registerProjectForm.value.endDate;
      this.projectService.postNewProject(this.newProject).subscribe(data => {console.log("sucesso = ", data);});

    }
    this.registerProjectForm.reset();
  }
}
