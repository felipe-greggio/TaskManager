import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Task } from '../Models/Task';

@Injectable({
  providedIn: 'root'
})
export class TaskService extends BaseService{

  constructor(private http : HttpClient) {
    super();

  }


  postNewTask(newTask:Task): Observable<any> {
    return this.http.post(`${environment.apiUrl}/Tasks/RegisterNewTask`, newTask, super.getRequestHeaders())
  }

  updateTask(taskId: string, task:Task): Observable<Task>{
    return this.http.put<Task>(`${environment.apiUrl}/Tasks/UpdateTask/${taskId}`, task, super.getRequestHeaders());
  }

}
