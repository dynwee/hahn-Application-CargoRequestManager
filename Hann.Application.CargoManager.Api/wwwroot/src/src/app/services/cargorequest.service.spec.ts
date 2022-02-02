import { TestBed } from '@angular/core/testing';

import { CargorequestService } from './cargorequest.service';

describe('CargorequestService', () => {
  let service: CargorequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CargorequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
