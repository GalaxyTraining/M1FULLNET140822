import { TestBed } from '@angular/core/testing';

import { AutenticationGuardService } from './autentication-guard.service';

describe('AutenticationGuardService', () => {
  let service: AutenticationGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutenticationGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
