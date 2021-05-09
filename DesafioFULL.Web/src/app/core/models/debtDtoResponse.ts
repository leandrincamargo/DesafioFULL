export interface DebtDtoResponse {
  number: number;
  debtorName: string;
  totalInstallments: number;
  originalValue: number;
  overDue: number;
  updatedValue: number;
}
