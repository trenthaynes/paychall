import { TestBed, inject } from '@angular/core/testing';

import { BenefitServiceService } from './benefit-service.service';

describe('BenefitServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BenefitServiceService]
    });
  });

  it('should be created', inject([BenefitServiceService], (service: BenefitServiceService) => {
    expect(service).toBeTruthy();
  }));
});
