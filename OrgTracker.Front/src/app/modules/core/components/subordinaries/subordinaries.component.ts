import { EmployeesService } from '@ot/services/employees.service';
import { Employee } from '@ot/entities/employee';
import { Component, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'subordinaries',
  templateUrl: './subordinaries.component.html',
  styleUrls: ['./subordinaries.component.css']
})
export class SubordinariesComponent {
  @Input() p_employeeId: number = 0;
  subordinaries: Employee[] = [] as Employee[];
  currentSubordinary: Employee = {} as Employee;

  constructor(private employeeService: EmployeesService) {}

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
      if (changes.hasOwnProperty(propName)) {
        switch (propName) {
          case 'p_employeeId': {
            if(this.p_employeeId !== undefined) {
              this.employeeService.getSubordinaries(this.p_employeeId)
              .subscribe(result => this.subordinaries = result);
            }
          }
        }
      }
    }
  }


  getName(employee: Employee) : string {
    return this.employeeService.getFullName(employee);
  }

  onAssignTask(subordinary: Employee) {
    this.currentSubordinary = subordinary;
  }
}
