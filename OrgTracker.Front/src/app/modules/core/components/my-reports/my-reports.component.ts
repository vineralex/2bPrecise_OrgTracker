import { ReportsService } from '@ot/services/reports.service';
import { Component, Input, SimpleChanges } from '@angular/core';
import { Report } from '@ot/entities/report';

@Component({
  selector: 'my-reports',
  templateUrl: './my-reports.component.html',
  styleUrls: ['./my-reports.component.css']
})

export class MyReportsComponent {
  @Input() p_employeeId: number = 0;
  reports: Report[] = [] as Report[];
 
  constructor(private reportService: ReportsService) { }

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
      if (changes.hasOwnProperty(propName)) {
        switch (propName) {
          case 'p_employeeId': {
            if(this.p_employeeId !== undefined) {
              this.reportService.getReportsFromSubordinaries(this.p_employeeId)
              .subscribe(result => this.reports = result);
            }
          }
        }
      }
    }
  }
}
