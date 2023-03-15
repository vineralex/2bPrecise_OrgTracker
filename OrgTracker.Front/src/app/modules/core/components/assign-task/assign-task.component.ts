import { Task } from './../../entities/task';
import { FormGroup, FormControl } from '@angular/forms';
import { TasksService } from '@ot/services/tasks.service';
import { Component, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'assign-task',
  templateUrl: './assign-task.component.html',
  styleUrls: ['./assign-task.component.css']
})
export class AssignTaskComponent {
  @Input() p_managerId: number = 0;
  @Input() p_assignToId: number = 0;
  task: Task = {} as Task;

  form = new FormGroup({
    taskText: new FormControl(),
    dueDate: new FormControl()
  });

  constructor(private taskService: TasksService) { }

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
      if (changes.hasOwnProperty(propName)) {
        switch (propName) {
          case 'p_assignToId': {
            
            this.task = {} as Task;
            
            this.form = new FormGroup({
              taskText: new FormControl(),
              dueDate: new FormControl()
            });
          }
        }
      }
    }
  }

  get taskText() : FormControl {
    return this.form.get('taskText') as FormControl;
  }

  get dueDate() : FormControl {
    return this.form.get('dueDate') as FormControl;
  }

  onTaskAssign() {
    this.task.text = this.taskText.value;
    this.task.dueDate = this.dueDate.value;
    this.taskService.create(this.task, this.p_managerId, this.p_assignToId)
    .subscribe(result => { });    
  }
}
