import { TasksService } from '@ot/services/tasks.service';
import { Component, Input, SimpleChanges } from '@angular/core';
import { Task } from '@ot/entities/task';

@Component({
  selector: 'my-tasks',
  templateUrl: './my-tasks.component.html',
  styleUrls: ['./my-tasks.component.css']
})
export class MyTasksComponent {

  @Input() p_employeeId: number = 0;
  tasks: Task[] = [] as Task[];

  constructor(private tasksService: TasksService) { }

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
      if (changes.hasOwnProperty(propName)) {
        switch (propName) {
          case 'p_employeeId': {
            if(this.p_employeeId !== undefined) {
              this.tasksService.getTasksAssignedToEmployee(this.p_employeeId)
              .subscribe(result => this.tasks = result);
            }
          }
        }
      }
    }
  }

}
