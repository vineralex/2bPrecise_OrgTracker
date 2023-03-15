import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { Employee } from '@ot/entities/employee';
import { EmployeesService } from '@ot/services/employees.service';

@Component({
  selector: 'employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {
  title = "Employee List"
  
  employees: Employee[] = new Array;

  constructor(
    private service: EmployeesService,
    private router: Router
    ) { }

  ngOnInit() {
    this.service.getAll()
      .subscribe(response => this.employees = response);
  }

  getFullName(employee: Employee): string {
    return this.service.getFullName(employee);
  }

  viewEmployee(employee: Employee) {
    let name = this.getFullName(employee);
    this.router.navigate(['employee', employee.id, name]);
  }
}
