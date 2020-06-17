import { TestBed } from '@angular/core/testing';

import { AuthGuard } from './auth.guard';
import { AppRoutingModule } from '../app-routing.module';

describe('AuthGuard', () => {
  let guard: AuthGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [  AppRoutingModule ]
    });
    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
