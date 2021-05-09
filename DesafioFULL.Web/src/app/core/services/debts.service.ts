import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ApiService } from './api.service';
import { map } from 'rxjs/operators';

import { DebtDtoResponse, DebtDtoRequest } from '../models';

@Injectable()
export class DebtsService {
  constructor(private apiService: ApiService) {}

  getAll(): Observable<DebtDtoResponse[]> {
    return this.apiService.get('/debts').pipe(map((data) => data));
  }

  save(debtRequest: DebtDtoRequest): Observable<DebtDtoResponse> {
    return this.apiService.post('/debts', debtRequest).pipe(map((data) => data));
  }
}
