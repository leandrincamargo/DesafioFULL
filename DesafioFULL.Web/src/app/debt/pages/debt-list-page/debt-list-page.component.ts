import { Component, OnInit } from '@angular/core';

import { DebtDtoResponse, DebtsService } from 'src/app/core';

@Component({
  selector: 'app-debt-list-page',
  templateUrl: './debt-list-page.component.html',
  styleUrls: ['./debt-list-page.component.scss'],
})
export class DebtListPageComponent implements OnInit {
  constructor(private debtsService: DebtsService) {}

  debts: DebtDtoResponse[] = [];
  displayedColumns: string[] = [
    'number',
    'debtorName',
    'totalInstallments',
    'originalValue',
    'overDue',
    'updatedValue',
  ];

  ngOnInit(): void {
    this.debtsService.getAll().subscribe((debts) => (this.debts = debts));
  }
}
