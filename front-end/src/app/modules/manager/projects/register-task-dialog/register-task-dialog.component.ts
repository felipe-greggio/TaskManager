import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, Inject, NgZone, OnInit, ViewChild  } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';
import { Task } from 'src/app/shared/Models/Task';
import { User } from 'src/app/shared/Models/User';
import { TaskService } from 'src/app/shared/Services/task-service.service';

@Component({
  selector: 'app-register-task-dialog',
  templateUrl: './register-task-dialog.component.html',
  styleUrls: ['./register-task-dialog.component.css']
})
export class RegisterTaskDialogComponent implements OnInit {

  @ViewChild('autosize') autosize!: CdkTextareaAutosize;


registerTaskForm!: FormGroup;
newTask: Task = {};
usersList: User[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<RegisterTaskDialogComponent>,
    public taskService: TaskService,
    private _ngZone: NgZone
  ) { }

  ngOnInit(): void {

    console.log("response= ", this.data.key);
    this.usersList = this.data.key.users;
    this.registerTaskForm = this.formBuilder.group({
      title:[''],
      description:[''],
      dueDate:[''],
      userId:['']
    });
  }



  cancelClick(): void {
    this.dialogRef.close();
    this.registerTaskForm.reset();
  }

  registerNewTask(){
    var confirmation = window.confirm("Are you sure you want to register a new project?");
    if(confirmation){
      this.newTask.title = this.registerTaskForm.value.title;
      this.newTask.description = this.registerTaskForm.value.description;
      this.newTask.dueDate = this.registerTaskForm.value.dueDate;
      this.newTask.startDate = new Date().toISOString();
      this.newTask.userId = this.registerTaskForm.value.userId;
      this.newTask.projectId = this.data.key.projectId;

      console.log("task= ", this.newTask);
      this.taskService.postNewTask(this.newTask as Task).subscribe((data: any) => {console.log("sucesso = ", data);});

    }
    this.registerTaskForm.reset();
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1)).subscribe(() => this.autosize.resizeToFitContent(true));
  }
}
