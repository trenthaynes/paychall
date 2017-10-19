import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-runningtotal',
  templateUrl: './runningtotal.component.html',
  styleUrls: ['./runningtotal.component.css']
})
export class RunningtotalComponent implements OnInit {
  @Input() electionCount: number;
  calcDisplay: string[] = [];
  primary: string;
  dependents: string;
  total: string;
  factor: number = .03846;

  constructor() { };

  ngOnInit() {
  };

  ngOnChanges(changes: SimpleChanges) {
    for (let propName in changes) {  
      if (propName === 'electionCount') {
        this.updateCalcDisplay();
      }
    }
  };

  updateCalcDisplay(){
    this.calcDisplay = [];
    let pval = 1000 * this.factor;
    let dval = (500 * (this.electionCount - 1)) * this.factor;
    let tval = pval + dval;
    this.primary = 'Primary: $' + pval + '/pay period ';
    this.dependents = 'Dependents: $' + dval + '/pay period';
    this.total = 'Total: $' + tval + '/pay period';
    this.calcDisplay.push(this.primary);
    if (this.electionCount > 1) {
      this.calcDisplay.push(this.dependents);
    }
    this.calcDisplay.push(this.total);
  };
}
