import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { Project } from 'src/app/shared/Models/Project';
import { Task } from 'src/app/shared/Models/Task';
import { BaseService } from 'src/app/shared/Services/base-service.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {

  constructor(private http:HttpClient) {
    super();

  }

  getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${environment.apiUrl}/Projects/GetAllProjects`, super.getRequestHeaders());
  }

  getProjectInfo(projectId: string): Observable<Project> {
    return this.http.get<Project>(`${environment.apiUrl}/Projects/GetProjectInfo/${projectId}`, super.getRequestHeaders())
            .pipe(catchError(super.handleError));
  }


  postNewProject(newProject:Project): Observable<any> {
    return this.http.post(`${environment.apiUrl}/Projects`, newProject, super.getRequestHeaders());
  }

  updateTask(taskId: string, task:Task): Observable<Task>{
    return this.http.put<Task>(`${environment.apiUrl}/Tasks/${taskId}`, task, super.getRequestHeaders());
  }
}
