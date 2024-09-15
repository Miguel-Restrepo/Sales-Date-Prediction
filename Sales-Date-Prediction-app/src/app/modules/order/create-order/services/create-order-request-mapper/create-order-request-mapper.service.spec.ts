import { TestBed } from '@angular/core/testing';

import { CreateOrderRequestMapperService } from './create-order-request-mapper.service';

describe('CreateOrderRequestMapperService', () => {
  let service: CreateOrderRequestMapperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateOrderRequestMapperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
