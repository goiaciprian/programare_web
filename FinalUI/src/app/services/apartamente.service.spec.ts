import { TestBed } from '@angular/core/testing';

import { ApartamenteService } from './apartamente.service';

describe('ApartamenteService', () => {
  let service: ApartamenteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApartamenteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
