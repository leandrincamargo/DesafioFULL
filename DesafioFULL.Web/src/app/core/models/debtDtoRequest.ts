import { InstallmentDtoRequest } from './installmentDtoRequest';

export interface DebtDtoRequest {
  number: number;
  debtorName: string;
  debtorCpf: string;
  interestPercent: number;
  penaltyPercent: number;
  installments: InstallmentDtoRequest[];
}
