import { TestBed } from '@angular/core/testing';

import { ShiftService } from './shift.service';
import { HttpClientModule } from '@angular/common/http';

describe('ShiftService', () => {
  let service: ShiftService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientModule ]
    });
    service = TestBed.inject(ShiftService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
