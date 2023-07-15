import { Component, OnInit } from '@angular/core';
import { ProjectService } from './services/project-service.service';
import { Project } from 'src/app/shared/Models/Project';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

projectList: Project[] = [];

  constructor(public projectService: ProjectService) {

    this.projectService.getAllProjects().subscribe(projects => {
      console.log(projects);
      this.projectList = projects;
    });

  }


  ngOnInit(): void {
  }

}
