import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';

import { Employee }  from '../../models/employee';
import { Dependent } from '../../models/dependent.interface';


@Component({
  selector: 'app-benefitdependent',
  templateUrl: './benefitdependent.component.html',
  styleUrls: ['./benefitdependent.component.css']
})
export class BenefitdependentComponent implements OnInit {
  public myForm: FormGroup;
  currentElections: number = 1;
  
  constructor(
    private _fb: FormBuilder,
    private location: Location
  ) { };

  @Output() notify: EventEmitter<number> = new EventEmitter<number>();
  
  goBack(): void {
    this.location.back();
  };

  ngOnInit() {
    this.myForm = this._fb.group({
        dependents: this._fb.array([
            this.initDependents(),
        ])
    });
    this.callNotify();
  };

  initDependents() {
    return this._fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    });
  };

  addDependent() {
      const control = <FormArray>this.myForm.controls['dependents'];
      control.push(this.initDependents());
      this.currentElections++;
      this.callNotify();
  };

  removeDependent(i: number) {
      const control = <FormArray>this.myForm.controls['dependents'];
      control.removeAt(i);
      this.currentElections--;
  };

  save(model: Dependent) {
      // call API to save
      // ...
      console.log(model);
  };

  callNotify(){
    this.notify.emit(this.currentElections);
  };
}
