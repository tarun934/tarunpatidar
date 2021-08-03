import { TestBed } from '@angular/core/testing';

import { CoursesDetailService } from './courses-detail.service';

describe('CoursesDetailService', () => {
  let service: CoursesDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoursesDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
