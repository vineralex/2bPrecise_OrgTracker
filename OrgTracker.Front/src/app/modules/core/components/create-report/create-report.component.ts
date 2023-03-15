import { Report } from '@ot/entities/report';
import { Component, Input, SimpleChanges } from '@angular/core';
import { ReportsService } from '@ot/services/reports.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'create-report',
  templateUrl: './create-report.component.html',
  styleUrls: ['./create-report.component.css']
})
export class CreateReportComponent {
  @Input() p_employeeId: number = 0;
  @Input() p_managerId: number = 0;
  report: Report = {} as Report;
  form = new FormGroup({
    reportText: new FormControl()
  });

  constructor(private reportService: ReportsService) { }

  get reportText() : FormControl {
    return this.form.get('reportText') as FormControl;
  }

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
      if (changes.hasOwnProperty(propName)) {
        switch (propName) {
          case 'p_employeeId': {
            
            this.report = {} as Report;
            
            this.form = new FormGroup({
              reportText: new FormControl()
            });
          }
        }
      }
    }
  }

  onPostReport() {
    this.report.text = this.reportText.value;
    this.reportService.create(this.report, this.p_managerId, this.p_employeeId)
    .subscribe(result => {});
  }
}
