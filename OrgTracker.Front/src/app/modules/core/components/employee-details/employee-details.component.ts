import { EmployeesService } from '@ot/services/employees.service';
import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Employee } from '@ot/entities/employee';
import { filter } from 'rxjs/internal/operators/filter';

@Component({
  selector: 'employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent {

  employee: Employee = { manager: {} as Employee} as Employee;
  manager: Employee = {} as Employee;
 
  employeeId: number = 0;

  constructor(
    private route: ActivatedRoute, 
    private emploeeService: EmployeesService, 
    private router: Router) { 
      this.route.paramMap.subscribe(params => {
        this.ngOnInit();
      });
    }

  ngOnInit() {
    this.route.paramMap
      .subscribe(params => {
        let id = params.get("id");
        this.employeeId = id ? +id : 0;
      });
    
      this.emploeeService.getDetails(this.employeeId)
      .subscribe(result => this.employee = result);      
  }

  getFullName(): string {
    return this.getName(this.employee);
  }  

  getName(employee: Employee): string {
    if(!!employee){
      return `${employee.firstName} ${employee.lastName}`;
    }
    return '';    
  }
}
