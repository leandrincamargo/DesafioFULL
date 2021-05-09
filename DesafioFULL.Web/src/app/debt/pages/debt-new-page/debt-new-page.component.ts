import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DebtDtoRequest, DebtsService, InstallmentDtoRequest } from 'src/app/core';

@Component({
  selector: 'app-debt-new-page',
  templateUrl: './debt-new-page.component.html',
  styleUrls: ['./debt-new-page.component.scss'],
})
export class DebtNewPageComponent {
  debtForm = this.fb.group({
    number: [null, Validators.required],
    debtorName: [null, Validators.required],
    debtorCpf: [null, Validators.required],
    interestPercent: [null, Validators.required],
    penaltyPercent: [null, Validators.required],
  });

  public installments: InstallmentDtoRequest[] = [];

  constructor(
    private fb: FormBuilder,
    private debtsService: DebtsService,
    private router: Router,
  ) {}

  onSubmit() {
    if (this.debtForm.valid && this.installments.length > 0) {
      const debtDto: DebtDtoRequest = {
        ...this.debtForm.value,
        installments: this.installments,
      };
      this.debtsService.save(debtDto).subscribe(() => {
        alert('Cadastro efetuado com sucesso');
        this.router.navigateByUrl('/');
      });
    } else alert('Formulário inválido');
  }
}
