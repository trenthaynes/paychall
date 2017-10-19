import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location }                 from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Employee } from '../../models/employee';
import { Meta } from '../../models/meta';
import { BenefitService } from '../../services/benefit.service';
import { BenefitdependentComponent } from '../../common/benefitdependent/benefitdependent.component';

@Component({
  selector: 'emp-detail',
  templateUrl: './emp-detail.component.html',
  styleUrls: ['./emp-detail.component.css']
})
export class EmpDetailComponent implements OnInit {
  @Input() employee: Employee;
  addedDependents: Employee[];
  meta: Meta;
  electionCount: number;

  constructor(
    private benefitService: BenefitService,
    private route: ActivatedRoute,
    private location: Location
  ){};
  
  ngOnInit(): void {
    this.route.paramMap
      .switchMap((params: ParamMap) => this.benefitService.getEmployee(+params.get('id')))
      .subscribe(emp => this.employee = emp);
  }; 

  onNotify(message:number):void {
    this.electionCount = message; 
  };
}
