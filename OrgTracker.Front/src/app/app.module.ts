import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EmployeesComponent } from '@ot/components/employees/employees.component';
import { EmployeeDetailsComponent } from '@ot/components/employee-details/employee-details.component';
import { EmployeesService } from '@ot/services/employees.service';
import { AppErrorHandler } from '@ot/errors/app-error-handler';
import { NotFoundPageComponent } from '@ot/components/not-found-page/not-found-page.component';
import { SubordinariesComponent } from '@ot/components/subordinaries/subordinaries.component';
import { ReportsService } from '@ot/services/reports.service';
import { TasksService } from '@ot/services/tasks.service';
import { MyTasksComponent } from '@ot/components/my-tasks/my-tasks.component';
import { MyReportsComponent } from '@ot/components/my-reports/my-reports.component';
import { CreateReportComponent } from '@ot/components/create-report/create-report.component';
import { AssignTaskComponent } from '@ot/components/assign-task/assign-task.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeDetailsComponent,
    NotFoundPageComponent,
    SubordinariesComponent,
    MyTasksComponent,
    MyReportsComponent,
    CreateReportComponent,
    AssignTaskComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: EmployeesComponent},
      {path: 'employee/:id/:name', component: EmployeeDetailsComponent},
      {path: '**', component: NotFoundPageComponent}
    ], {onSameUrlNavigation: 'reload'}),
    NgbModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    EmployeesService,
    TasksService,
    ReportsService,
    { provide: ErrorHandler, useClass: AppErrorHandler },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
