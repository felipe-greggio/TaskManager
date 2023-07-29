import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, Inject, NgZone, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { take } from 'rxjs';
import { Task } from 'src/app/shared/Models/Task';
import { User } from 'src/app/shared/Models/User';
import { TaskService } from 'src/app/shared/Services/task-service.service';


@Component({
  selector: 'app-update-task-dialog',
  templateUrl: './update-task-dialog.component.html',
  styleUrls: ['./update-task-dialog.component.css']
})
export class UpdateTaskDialogComponent {
  @ViewChild('autosize') autosize!: CdkTextareaAutosize;

injectedTask!: Task;
updateTaskForm!: FormGroup;
updatedTask: Task = {};
usersList: User[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<UpdateTaskDialogComponent>,
    public taskService: TaskService,
    private _ngZone: NgZone
  ) { }

  ngOnInit(): void {

    console.log("response= ", this.data);
    this.usersList = this.data.key.users;
    this.injectedTask = this.data.task;
    this.updateTaskForm = this.formBuilder.group({
      title:[''],
      description:[''],
      dueDate:[''],
      userId:['']
    });
  }



  cancelClick(): void {
    this.dialogRef.close();
    this.updateTaskForm.reset();
  }

  updateTask(){
    var confirmation = window.confirm("Are you sure you want to register a new project?");
    if(confirmation){
      this.updatedTask.taskId = this.injectedTask.taskId;
      this.updatedTask.title = this.updateTaskForm.value.title;
      this.updatedTask.description = this.updateTaskForm.value.description;
      this.updatedTask.dueDate = this.updateTaskForm.value.dueDate;
      this.updatedTask.startDate = this.injectedTask.dueDate;
      this.updatedTask.userId = this.updateTaskForm.value.userId;
      this.updatedTask.projectId = this.data.key.projectId;
      this.updatedTask.status = this.injectedTask.status;

      console.log("task= ", this.updatedTask);
      this.taskService.updateTask(this.injectedTask.taskId as string, this.updatedTask).subscribe(
        updatedTask => {
          console.log("Task updated: ", updatedTask);
        },
        error => {
          console.error("Update task failed: ", error);
        }
      );

    }
    this.updateTaskForm.reset();
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1)).subscribe(() => this.autosize.resizeToFitContent(true));
  }

}


