import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Endpoints } from '@ot/config/endpoints';
import { Task } from '@ot/entities/task';

@Injectable({
  providedIn: 'root'
})
export class TasksService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getTasksAssignedToEmployee(employeeId: number): Observable<Task[]>  {
    const url = Endpoints.api.task.tasksAssignedToEmployee
    .replace('{employeeId}', employeeId.toString());
    const observable = this.http.get<Task[]>(url)
    .pipe(catchError(this.handleError));    
    return observable;
  }

  create(task: Task, managerId: number, assignToId: number): Observable<Task[]>  {
    const url = Endpoints.api.task.create
    .replace('{managerId}', managerId.toString())
    .replace('{assignToId}', assignToId.toString());
    const observable = this.http.post<Task[]>(url, task)
      .pipe(catchError(this.handleError));
    return observable;
  }

}
