import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BenefitdependentComponent } from './benefitdependent.component';

describe('BenefitdependentComponent', () => {
  let component: BenefitdependentComponent;
  let fixture: ComponentFixture<BenefitdependentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BenefitdependentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitdependentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
