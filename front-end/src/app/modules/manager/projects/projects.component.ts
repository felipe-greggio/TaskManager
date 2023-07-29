import { Component, OnInit } from '@angular/core';
import { ProjectService } from './services/project-service.service';
import { Project, ProjectStatus } from 'src/app/shared/Models/Project';
import { FormControl } from '@angular/forms';
import { RegisterTaskDialogComponent } from './register-task-dialog/register-task-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { User } from 'src/app/shared/Models/User';
import { EnumTaskStatus, Task } from 'src/app/shared/Models/Task';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

projectList: Project[] = [];
selectedProject!: any;
projectInfo!: Project;
projectUsers: User[] = [];
notStartedTasks: Task[] = [];
postponedTasks: Task[] = [];
inProgressTasks: Task[] = [];
doneTasks: Task[] = [];
statuses: number[] = [0,1,2,3];

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
      this.projectUsers = response.users ?? [];
      this.notStartedTasks = this.getTasksByStatus(EnumTaskStatus.NotStarted);
      this.postponedTasks = this.getTasksByStatus(EnumTaskStatus.Postponed);
      this.inProgressTasks = this.getTasksByStatus(EnumTaskStatus.Progress);
      this.doneTasks = this.getTasksByStatus(EnumTaskStatus.Done);
    })
  }

  getProjectStatus(status: ProjectStatus): string {
    return ProjectStatus[status];
  }

  openRegisterTaskDialog(){
    const data = { key: this.projectInfo };
    const dialogRef = this.dialog.open(RegisterTaskDialogComponent, { data });
  }

  getTasksByStatus(status: number): Task[] {
    return this.projectUsers.flatMap(user => user.tasks == undefined ? [] : user.tasks.filter(task => task.status === status));
  }

  getTasksForStatus(user: User, status: number): Task[] {
    return user.tasks == undefined ? [] : user.tasks.filter(task => task.status === status);
  }

  drop(event: CdkDragDrop<Task[]>, newStatus: number): void {
    if (event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );

      let task = event.container.data[event.currentIndex];
      // Here we are converting the newStatus to its corresponding EnumTaskStatus value
      //task.status = EnumTaskStatus[newStatus as keyof typeof EnumTaskStatus];
      task.status = newStatus;

      // Call your update method here
      this.projectService.updateTask(task.taskId as string, task).subscribe(
        updatedTask => {
          // Handle success
          console.log("Task updated: ", updatedTask);
        },
        error => {
          // Handle error
          console.error("Update task failed: ", error);
        }
      );
    }
  }


}
