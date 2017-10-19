import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../models/employee';
import { BenefitService } from '../services/benefit.service'


@Component({
  selector: 'app-emp',
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css']
})

export class EmpComponent implements OnInit {
  selectedEmployee: Employee;
  employees: Employee[];
  checkboxValue: boolean;

  constructor(
    private router: Router,
    private benefitService: BenefitService) { };
    
  ngOnInit(): void {
    this.getEmployees();
  };
  getEmployees(): void {
    this.benefitService.getEmployees().then(employees => this.employees = employees);
  };
  onSelect(employee: Employee): void {
    this.selectedEmployee = employee;
  };
  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedEmployee.employeeId]);
  }
  onNotify(message:Employee):void {
    this.selectedEmployee = message;
    if (this.checkboxValue) {
      this.router.navigate(['/detail', this.selectedEmployee.employeeId]);  
    }
  };
}
