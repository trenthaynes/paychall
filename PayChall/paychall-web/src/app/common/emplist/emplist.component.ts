import { Component, OnInit, EventEmitter, Output } from '@angular/core';

import { BenefitService } from '../../services/benefit.service';
import { Employee } from '../../models/employee'

@Component({
  selector: 'app-emplist',
  templateUrl: './emplist.component.html',
  styleUrls: ['./emplist.component.css']
})

export class EmplistComponent implements OnInit {
  employees: Employee[];
  selectedEmployee: Employee;

  @Output() notify: EventEmitter<Employee> = new EventEmitter<Employee>();
  
  constructor(private benefitService: BenefitService) { };
  
  ngOnInit() {
    this.benefitService.getEmployees()
      .then(emps => this.employees = emps);
  }

  onChange(employee) {
    this.notify.emit(employee);
  }

}
