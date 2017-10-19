import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RunningtotalComponent } from './runningtotal.component';

describe('RunningtotalComponent', () => {
  let component: RunningtotalComponent;
  let fixture: ComponentFixture<RunningtotalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RunningtotalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RunningtotalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
