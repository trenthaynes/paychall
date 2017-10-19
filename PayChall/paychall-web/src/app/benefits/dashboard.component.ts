import { Component, OnInit } from '@angular/core';

import { Employee } from '../models/employee';
import { BenefitService } from '../services/benefit.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {
  employees: Employee[];

  constructor(private benefitService: BenefitService) { };
  
  ngOnInit() {
    this.benefitService.getEmployees()
      .then(emps => this.employees = emps);
  }
}
