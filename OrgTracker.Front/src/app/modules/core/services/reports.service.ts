import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Endpoints } from '@ot/config/endpoints';
import { Report } from '@ot/entities/report';

@Injectable({
  providedIn: 'root'
})
export class ReportsService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getReportsFromSubordinaries(managerId: number): Observable<Report[]>  {
    const url = Endpoints.api.report.reportsFromSubordinaries
    .replace('{managerId}', managerId.toString());
    const observable = this.http.get<Report[]>(url)
      .pipe(catchError(this.handleError));
    return observable;
  }

  create(report: Report, managerId: number, employeeId: number): Observable<Report[]>  {
    const url = Endpoints.api.report.create
    .replace('{employeeId}', employeeId.toString())
    .replace('{managerId}', managerId.toString());
    const observable = this.http.post<Report[]>(url, report)
      .pipe(catchError(this.handleError));
    return observable;
  }
}
