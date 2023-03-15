import { BaseService } from './base.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '@ot/entities/employee';
import { Endpoints } from '@ot/config/endpoints';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getAll(): Observable<Employee[]>  {
    const url = Endpoints.api.employee.employeeList;
    const observable = this.http.get<Employee[]>(url)
      .pipe(catchError(this.handleError));
    return observable;
  }

  getDetails(id: number): Observable<Employee> {
    const url = Endpoints.api.employee.employeeDetails.replace('{id}', id.toString());
    const observable = this.http.get<Employee>(url)
      .pipe(catchError(this.handleError));
    return observable;
  }

  getSubordinaries(id: number): Observable<Employee[]> {
    const url = Endpoints.api.employee.getSubordinaries.replace('{id}', id.toString());
    const observable = this.http.get<Employee[]>(url)
      .pipe(catchError(this.handleError));
    return observable;
  }

  getFullName(employee: Employee) :string {
    if(!!employee) {
      return `${employee.firstName} ${employee.lastName}`;
    }
    return '';
  }
}
