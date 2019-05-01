import { TestBed } from '@angular/core/testing';

import { MovieDatabaseService } from './movie-database.service';

describe('MovieDatabaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MovieDatabaseService = TestBed.get(MovieDatabaseService);
    expect(service).toBeTruthy();
  });
});
